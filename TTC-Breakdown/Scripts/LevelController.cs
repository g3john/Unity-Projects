using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    float time;
    public Text closurelisttext;
    public Text timetext;
    public Line line1and2;
    public Line line2and3;
    public Line line3and4;
    public Line line2and5;
    public Line line5and3;

    void Start () {
        time = 0.0f;
        //makeLines();
	}
    //void makeLines() {
        //get a list of all the lines
    //}

    //Line findLine(Station src, Station dst) {
        //return line between station src and station dst
       // return null;
    //}
    void updateController(Line line){
        time += 2.0f;
        timetext.text = "Time: " + time;
        if (time == 2.0) {
            //findLine(station2, station3).running = false;
            line2and3.running = false;
            closurelisttext.text += "There is a closure between Station 2 and 3\n";
        }        

    } 

}
