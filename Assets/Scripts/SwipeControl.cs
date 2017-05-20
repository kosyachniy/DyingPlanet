using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    bool rightswipe = false;
    bool leftswipe = false;
    bool topswipe = false;
    bool downswipe = false;
    private Vector3 fp;   //Первая позиция касания
    private Vector3 lp;   //Последняя позиция касания
    private float dragDistance;  //Минимальная дистанция для определения свайпа
    private List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке

   // Use this for initialization
    void Start () {
        dragDistance = Screen.height * 5 / 100; //dragDistance это 5% высоты экрана
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (rightswipe)
        {
            Vector3 movement = new Vector3(rb.position.x + 10 * Time.deltaTime, rb.position.y, rb.position.z);
            rb.position = movement;
        }
        else if (leftswipe)
        {
            Vector3 movement = new Vector3(rb.position.x - 10 * Time.deltaTime, rb.position.y, rb.position.z);
            rb.position = movement;
        }
        //if (topswipe)
        //{
        //    if (rb.position.y < 5)//Высота прыжка
        //    {
        //            rb.velocity = new Vector3(rb.velocity.x, 10, rb.velocity.z);
        //    }
        //    topswipe = false;
        //}
        foreach (Touch touch in Input.touches)  //используем цикл для отслеживания больше одного свайпа
            { //должны быть закоментированы, если вы используете списки 
              /*if (touch.phase == TouchPhase.Began) //проверяем первое касание
              {
                  fp = touch.position;
                  lp = touch.position;

              }*/

                if (touch.phase == TouchPhase.Moved) //добавляем касания в список, как только они определены
                {
                    touchPositions.Add(touch.position);
                }

                if (touch.phase == TouchPhase.Ended) //проверяем, если палец убирается с экрана
                {
                    //lp = touch.position;  //последняя позиция касания. закоментируйте если используете списки
                    fp = touchPositions[0]; //получаем первую позицию касания из списка касаний
                    lp = touchPositions[touchPositions.Count - 1]; //позиция последнего касания

                    //проверяем дистанцию перемещения больше чем 20% высоты экрана
                    if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                    {//это перемещение
                     //проверяем, перемещение было вертикальным или горизонтальным 
                        if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                        {   //Если горизонтальное движение больше, чем вертикальное движение ...
                            if ((lp.x > fp.x))  //Если движение было вправо
                            {
                            //Свайп вправо
                            //rb.velocity = new Vector3(10, rb.velocity.y, rb.velocity.z);
                            rightswipe = true;
                            leftswipe = false;
                            Debug.Log("Right Swipe");
                            }
                            else
                            {
                            //Свайп влево
                            //rb.velocity = new Vector3(-10, rb.velocity.y, rb.velocity.z);
                            rightswipe = false;
                            leftswipe = true;
                            Debug.Log("Left Swipe");
                            }
                        }
                        else {   //Если вертикальное движение больше, чнм горизонтальное движение
						if (lp.y > fp.y) { //Если движение вверх
                            //Свайп вверх  
							if (rb.position.y < 5) { //Высота прыжка
                                rb.velocity = new Vector3(rb.velocity.x, 5, rb.velocity.z);
                            }
                            Debug.Log("Up Swipe");
                            }
                            else
                            {   
                            //Свайп вниз
                                Debug.Log("Down Swipe");
                            }
                        }
                    }
                }
                else
                {   //Это ответвление, как расстояние перемещения составляет менее 20% от высоты экрана

                }
            }
        //rb.AddForce(movement);
    }
}
