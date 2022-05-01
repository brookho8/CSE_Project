using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class LevelControl : MonoBehaviour
{

    public Transform cameraFollowTarget;
    public Vector3 followVelocity;
    public float smoothTime;
    public float cameraZDist;

    // Start is called before the first frame update
    void Start()
    {
        readTextTwoElectricBoogaloo("Assets\\Resources\\levelCSV3.txt");
        //readTextFileToLevel("Assets\\Resources\\level.txt");
        followVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraFollowTarget.position + new Vector3(0, 0, cameraZDist);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, smoothTime);
    }


    void readTextTwoElectricBoogaloo(string file_path){

        GameObject wallTemplate = Resources.Load("wall") as GameObject;

        string fileData  = System.IO.File.ReadAllText(file_path);
        string[] lines = fileData.Split("\n");


        int columnCount = 0;
        int rowCount = 0;

        foreach(string line in lines){
            columnCount = 0;
            string[] lineData = (line.Trim()).Split(",");
            foreach(string code in lineData){
                if (code != "0"){
                    Sprite spriteToUse = Resources.Load<Sprite>("tileyboys\\tile_" + code);
                    Debug.Log(spriteToUse);
                    GameObject wall = Instantiate(wallTemplate, new Vector3(columnCount, rowCount, 0), Quaternion.identity) as GameObject;
                    SpriteRenderer rendr = wall.GetComponent<SpriteRenderer>();
                    rendr.sprite = spriteToUse;
                }
                columnCount += 1;
            }
            rowCount += 1;
        }

        // var lineData : String[] = (lines[0].Trim()).Split(","[0]);
        // float.TryParse(lineData[0], x);
    }

    void readTextFileToLevel(string file_path)
    {

        GameObject wallTemplate = Resources.Load("wall") as GameObject;
        GameObject goalTemplate = Resources.Load("goal") as GameObject;

        StreamReader inp_stm = new StreamReader(file_path);
        int rowCount = 0;
        int columnCount = 0;

        int rightSide = -1;
        int topSide = -1;

        while(!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            columnCount = 0;
            foreach (char c in inp_ln){
                //Logic
                if (c == '0'){
                    GameObject wall = Instantiate(wallTemplate, new Vector3(columnCount, rowCount, 0), Quaternion.identity) as GameObject;
                }
                else if (c == '1'){

                }
                columnCount += 1;
            }
            rowCount += 1;
            rightSide = columnCount;
            topSide = rowCount;
        }
        inp_stm.Close( );

        int padSize = 20;
        for(int i = 0; i <= rightSide; i++){
            for (int pad = 0; pad < padSize; pad++){
                // Top Padding
                GameObject wall = Instantiate(wallTemplate, new Vector3(i, topSide + pad, 0), Quaternion.identity) as GameObject;

                //Bottom Padding
                GameObject wall2 = Instantiate(wallTemplate, new Vector3(i, -1 - pad, 0), Quaternion.identity) as GameObject;
            }
        }

        for(int i = -1*padSize; i < topSide+padSize; i++){
            for (int pad = 0; pad < padSize; pad++){
                // Left Padding
                GameObject wall2 = Instantiate(wallTemplate, new Vector3(-1 - pad, i, 0), Quaternion.identity) as GameObject;
            }
        }

        for (int i = 0; i < topSide; i++){
            // Right Padding
            GameObject wall = Instantiate(goalTemplate, new Vector3(rightSide, i, 0), Quaternion.identity) as GameObject;
        }
    }

}
