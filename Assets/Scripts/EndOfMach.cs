using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMach : MonoBehaviour
{
    [SerializeField] GameObject[] characters = new GameObject[15];
    // Start is called before the first frame update
    void Start()
    {
        InstantiateCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateCharacters()
    {
        foreach(GameObject character in characters)
        {
            float rotationY = character.transform.rotation.y * 2;
            Quaternion rotationQuaternion = new Quaternion(character.transform.rotation.x, rotationY, character.transform.rotation.z, character.transform.rotation.w);
            Vector3 cloneScale= new Vector3(0.3824849f, 0.3824849f, 0.3824849f);

            if (character.name == DataManager.Instance.PvPWinner)
            {
               
                GameObject winnerClone=Instantiate(character, new Vector3(-0.05f, 1.335f, -7.829f),rotationQuaternion);
                winnerClone.transform.localScale = cloneScale;
                PlayerController playerController = winnerClone.GetComponent<PlayerController>();
                Rigidbody cloneRB=winnerClone.GetComponent<Rigidbody>();
                BoxCollider cloneCollider=winnerClone.GetComponent<BoxCollider>();
                cloneRB.constraints = RigidbodyConstraints.FreezePositionY;
                playerController.enabled = false;
                cloneCollider.enabled = false;
            }
            if (character.name == DataManager.Instance.PvPLoser)
            {
                GameObject loserClone = Instantiate(character, new Vector3(-0.387f, 1.157f, -7.641f), rotationQuaternion);
                loserClone.transform.localScale = cloneScale;
                PlayerController playerController = loserClone.GetComponent<PlayerController>();
                Rigidbody cloneRB = loserClone.GetComponent<Rigidbody>();
                BoxCollider cloneCollider = loserClone.GetComponent<BoxCollider>();
                cloneRB.constraints = RigidbodyConstraints.FreezePositionY;
                playerController.enabled = false;
                cloneCollider.enabled = false;
            }
        }
    }
}
