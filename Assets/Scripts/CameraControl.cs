using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{


    bool moveRight, moveLeft; // просто значения влево/вправо - [b]необязательны[/b] 
    Transform selfTransform, mainCamTransform; //сохраняем трансформ нашего объекта и камеры 
    [SerializeField]
    Camera mainView;    //вешаем сюда нашу камеру 
    Vector3 wantedPosition;

    // Use this for initialization
    void Start()
    {
        mainCamTransform = mainView.transform;
        selfTransform = transform;
        StartCoroutine(coUpdate());
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    IEnumerator coUpdate()
    {

        while (true)
        {
            if (moveRight)
            {
                wantedPosition = new Vector3(selfTransform.position.x + 100, mainCamTransform.position.y, mainCamTransform.position.z);
            }
            if (moveLeft)
            {
                wantedPosition = new Vector3(selfTransform.position.x - 100, mainCamTransform.position.y, mainCamTransform.position.z);
            }
            mainCamTransform.position = Vector3.Lerp(mainCamTransform.position, wantedPosition, Time.deltaTime * 5.0f); //плавно сдвигает камеру. В нашем случае по X 

            yield return 0;
        }
    }
}
