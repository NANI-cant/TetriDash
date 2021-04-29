using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombinationDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject flash;
    private SquaresLander _lander;
    private SquaresConnecter _connecter;
    public UnityAction OnCombinationDestroyStart;
    public UnityAction OnCombinationDestroyEnd;
    private bool isCoroutineStarted = false;
    private List<CombinationFinder> finders;

    private void Start(){
        _lander = GetComponent<SquaresLander>();
        _lander.OnSquaresLand += FindCombinations;
        _connecter = GetComponent<SquaresConnecter>();
        _connecter.OnSquareConnect += FindCombinations;
        finders = new List<CombinationFinder>(0);
    }

    public void AddNewFinder(CombinationFinder _finder){
        finders.Add(_finder);
    }

    public void DeleteFinder(CombinationFinder _finder){
        finders.Remove(_finder);
    }

    private void FindCombinations(){
        foreach (CombinationFinder finder in finders){
            if(finder.FindCombination()){
                break;
            }
        }
    }

    public void DestroyCombination(float yCoordinate){
        if(!isCoroutineStarted){
            isCoroutineStarted = true;
            StartCoroutine(nameof(DestroyingCoroutine),yCoordinate);
            isCoroutineStarted = false;
            OnCombinationDestroyEnd?.Invoke();
        }
    }

    private IEnumerator DestroyingCoroutine(float yCoordinate){
        OnCombinationDestroyStart?.Invoke();
        RaycastHit2D[] hitResults;
        hitResults = Physics2D.BoxCastAll(new Vector2(0,yCoordinate),new Vector2(40,1.5f),0,Vector2.zero);
        Instantiate(flash,new Vector3(0,yCoordinate,0),Quaternion.identity);
        yield return 1/6f;
        for(int i=0;i<hitResults.Length;i++){
            if(hitResults[i].collider.GetComponent<CombinationFinder>()!=null){
                Destroy(hitResults[i].collider.gameObject);
            }
        }
        _lander.Land(yCoordinate - 1);
        yield return 1/6f;
    }
}
