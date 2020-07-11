using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform target;
    void Start()
    {
       
    }

    bool isClick = false;
    void Update()
    {

        if (Input.GetMouseButton(0) && !isClick)
        {
            isClick = true;
            Debug.Log("click!");

            //1、设置一个新的旋转角度 
            //根据四元素旋转，这样子并不是转了90度。不熟悉建议不这样使用。
            //Quaternion rotate = new Quaternion(0, 0.9f, 0, 1);
            //transform.SetPositionAndRotation(Vector3.zero, rotate);

            //2、旋转到某个角度
            //根据角度转
            //transform.Rotate(0, -90, 0, Space.Self);

            //3、设置一个新的旋转角度
            //根据角度旋转
            //transform.eulerAngles = new Vector3(0, 30, 0);


            //4、过时的。且并没有想象中的围绕y轴旋转30度
            //transform.RotateAround(Vector3.up, 30);

            //5、设置一个新的角度
            //特点：操作的是z轴。自己的Z轴指向（1,0,0）某个角度
            transform.LookAt(Vector3.right);//right = （1,0,0）

            //6、Vector3.RotateTowards。使自己的z轴向某个方向旋转。
            //特点：（1）不是马上发生，每帧更新。（2）操作的是z轴。
            Vector3 targetDirection = target.position - transform.position;
            float singleStep = 1.0f * Time.deltaTime;

            //最后两个参数，角速度，角向量。下面的这段代码和transform.LookAt区别仅在于是否是缓慢发生的，且可控。
            //public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta);
            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.position, singleStep, 0f);
            //Debug.DrawRay(transform.position, newDirection, Color.red);
            //transform.rotation = Quaternion.LookRotation(newDirection);

            //7、使自己的z轴指向某个方向。
            //特点：每帧更新，穿入参数是四元数。
            //public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, singleStep);

            //8、Quaternion.LookRotation(Vector3 forward) 
            //特点：(1)作用与transform.LookAt相同,只是这里操作的是四元数
            //(2)立刻发生
            Quaternion rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = rotation;

            //9、Quaternion里的lerp和slerp。原理是和Vector3里的lerp和slerp一样的，只不过这里变化的是角度，传参换成了四元数。

            Debug.Log("transform.position = " + transform.position);
            Debug.Log("transform.rotation = " + transform.rotation);
            Debug.Log("transform.eulerAngles = " + transform.eulerAngles);
            Debug.Log("transform.localEulerAngles = " + transform.localEulerAngles);
        }
    }
}
