using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;



public class ArduinoCommunication : MonoBehaviour {

    public string port = "COM4";

    SerialPort myData;


    void Start()
    {
    
        myData = new SerialPort(port, 9600);
        /**
		foreach(string str in SerialPort.GetPortNames())
		{
			Debug.Log(string.Format("Port : {0}", str));
		}
		*/
        ledOn();
    }

    void Update()
    {

    }

    public void ledOn()
    {
        myData.Open(); //Open the Serial Stream.
                       // Debug.Log ("Com open");
        myData.WriteLine("ON");
        // Debug.Log ("Data sendt");
        myData.Close();
        // Debug.Log("Com closed");
    }

    public void ledOff()
    {
        myData.Open(); //Open the Serial Stream.
                       // Debug.Log ("Com open");
        myData.WriteLine("OFF");
        // Debug.Log ("Data sendt");
        myData.Close();
        // Debug.Log("Com closed");
    }


}
