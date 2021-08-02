using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGame : MonoBehaviour
{
    //int max;
    //public int GetSetMax
    //{
    //    get { return max; }
    //    set { max = value; }
    //}
    private int max { get; set; }

    bool rotation_active = true;
    List<int> rotation_num = new List<int>();

    GameObject cubePrefab;
    List<Transform> cube_list = new List<Transform>();
    List<Transform> Left_list { get { return cube_list.FindAll(a => a.transform.position.x == 8); } }
    List<Transform> Right_list { get { return cube_list.FindAll(a => a.transform.position.x == 10); } }
    List<Transform> Top_list { get { return cube_list.FindAll(a => a.transform.position.y == 24); } }
    List<Transform> Bottom_list { get { return cube_list.FindAll(a => a.transform.position.y == 22); } }
    List<Transform> Back_list { get { return cube_list.FindAll(a => a.transform.position.z == 2); } }
    List<Transform> Forward_list { get { return cube_list.FindAll(a => a.transform.position.z == 0); } }

    void Start()
    {
        //GetSetMax = 3;
        //Debug.Log(GetSetMax);
        max = 3;
        Debug.Log(max);

        cubePrefab = Resources.Load<GameObject>("Prefab/Cube");
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                for (int k = 0; k < max; k++)
                {
                    GameObject a = Instantiate(cubePrefab);
                    a.transform.position = new Vector3(8f + i, 22f + j, k);
                    a.name = "Cube(" + (8 + i).ToString() + ", " + (22 + j).ToString() + ", " + k.ToString() + ")";
                    cube_list.Add(a.transform);
                }
            }
        }
        for (int i = 0; i < 27; i++)
        {
            if (cube_list[i].transform.position.x == 8) cube_list[i].GetChild(3).gameObject.SetActive(true);
            if (cube_list[i].transform.position.x == 10) cube_list[i].GetChild(2).gameObject.SetActive(true);
            if (cube_list[i].transform.position.y == 22) cube_list[i].GetChild(5).gameObject.SetActive(true);
            if (cube_list[i].transform.position.y == 24) cube_list[i].GetChild(4).gameObject.SetActive(true);
            if (cube_list[i].transform.position.z == 0) cube_list[i].GetChild(0).gameObject.SetActive(true);
            if (cube_list[i].transform.position.z == 2) cube_list[i].GetChild(1).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (rotation_active && Input.GetKeyDown(KeyCode.Q)) StartCoroutine(Cube_rotation(Top_list, Vector3.up, 1));
        else if (rotation_active && Input.GetKeyDown(KeyCode.W)) StartCoroutine(Cube_rotation(Bottom_list, Vector3.up, 2));
        else if (rotation_active && Input.GetKeyDown(KeyCode.E)) StartCoroutine(Cube_rotation(Left_list, Vector3.right, 3));
        else if (rotation_active && Input.GetKeyDown(KeyCode.D)) StartCoroutine(Cube_rotation(Right_list, Vector3.right, 4));
        else if (rotation_active && Input.GetKeyDown(KeyCode.A)) StartCoroutine(Cube_rotation(Back_list, Vector3.forward, 5));
        else if (rotation_active && Input.GetKeyDown(KeyCode.S)) StartCoroutine(Cube_rotation(Forward_list, Vector3.forward, 6));

        else if (rotation_active && Input.GetKeyDown(KeyCode.P)) StartCoroutine(Cube_reload());
    }

    IEnumerator Cube_rotation(List<Transform> culist, Vector3 go, int num)
    {
        rotation_active = false;
        for (int i = 0; i < 18; i++)
        {
            foreach (Transform t in culist) t.RotateAround(new Vector3(9, 23, 1), go, 5f);
            yield return null;
        }
        for (int i = 0; i < culist.Count; i++)
        {
            culist[i].transform.position
                = new Vector3(Mathf.RoundToInt(culist[i].transform.position.x)
                , Mathf.RoundToInt(culist[i].transform.position.y)
                , Mathf.RoundToInt(culist[i].transform.position.z));
        }
        rotation_num.Add(num);
        rotation_active = true;
    }

    IEnumerator Cube_reload()
    {
        for (int i = rotation_num.Count - 1; i >= 0; i--)
        {
            if (rotation_num[i] == 1) StartCoroutine(Cube_rotation(Top_list, Vector3.down, 1));
            else if (rotation_num[i] == 2) StartCoroutine(Cube_rotation(Bottom_list, Vector3.down, 2));
            else if (rotation_num[i] == 3) StartCoroutine(Cube_rotation(Left_list, Vector3.left, 3));
            else if (rotation_num[i] == 4) StartCoroutine(Cube_rotation(Right_list, Vector3.left, 4));
            else if (rotation_num[i] == 5) StartCoroutine(Cube_rotation(Back_list, Vector3.back, 5));
            else if (rotation_num[i] == 6) StartCoroutine(Cube_rotation(Forward_list, Vector3.back, 6));

            yield return new WaitForSeconds(0.2f);
        }
        rotation_num.Clear();
    }
}