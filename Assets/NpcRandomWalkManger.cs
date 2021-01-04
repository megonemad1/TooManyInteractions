using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRandomWalkManger : MonoBehaviour
{
    [SerializeReference]
    AControler controler;
    IMove mover;
    [SerializeField]
    bool moving =true;

    public bool Moving { get => moving; set => moving = value; }

    private void Awake()
    {
        mover = controler.GetHandler<IMove>();
        StartCoroutine(moveRandom());
    }
    


    IEnumerator moveRandom()
    {
        while (true)
        {
            while (moving)
            {
                mover.Direction = new Vector2(Random.value * 2 - 1, Random.value * 2 - 1);
                yield return new WaitForSeconds(2);
                mover.Direction = Vector2.zero;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
