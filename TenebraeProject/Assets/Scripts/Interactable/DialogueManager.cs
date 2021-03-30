using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class DialogueManager : MonoBehaviour
{
    //TODO next: Set up prototype in Unity with the UI
    DNode[] DNodeArray;
    DNode now_node;
    int node_position = -1;
    const string skip =
        "#---------------------------------------------------------------------------";

    private void Start()
    {
        string[] lines = File.ReadAllLines(@"Assets/StoryBeats/dialogue1.txt");
        DNode[] DNodeArray = new DNode[100];
        

        //assign information into nodes
        for (int i = 0; i < lines.Length; i++)
        {
            switch (lines[i])
            {
                case "#newnode":
                    node_position++;
                    DNodeArray[node_position] = new DNode();
                    now_node = DNodeArray[node_position];
                    break;
                case "#key":
                    now_node.key = Byte.Parse((lines[i + 1]));
                    break;
                case "#branch":
                    //TODO end dialogue with -1 branch idea
                    now_node.branches = SeperateBranches(lines[i + 1]);
                    break;
                case "#sentences":
                    int sent_idx = 0; //now_node sentence array index
                    bool sentences = true; //false when at the next node 
                    while (sentences)
                    {
                        for (int k = i; k < lines.Length; k++)
                        {
                            if (lines[k].Length == 0) { sent_idx++; }
                            else if (lines[k] == "#key" || lines[k] == "#end")
                            //minus two because i is incredmented after the break
                            //needs to see the "#newline" and the next line after
                            { sentences = false; i = k - 2; break; }
                            else { now_node.sentences[sent_idx] = lines[k]; }
                        }
                    }
                    break;
                case "#choice":
                    //TODO work on logic for this part
                    break;
                case "#player":
                    //TODO work on logic for this part
                    break;
                case skip: //used to seperate the nodes
                    continue;
            }
        }

        //print out the nodes 
        foreach (DNode d in DNodeArray)
        {
            if (d != null)
                Debug.Log(d.key); //1,2
            else break; //prevent from iterating through whole array
        }
    }

    //Node Subclass
    private class DNode
    {
        public byte key;
        public byte[] branches = new byte[5];
        public string[] sentences = new string[100];
    }

    //Comma seperate branches
    private byte[] SeperateBranches(string s)
    {
        string[] sa = s.Split(','); //string array
        byte[] ba = new byte[sa.Length]; //same size as previous array
        for (int i = 0; i < sa.Length; i++)
        {
            ba[i] =  Byte.Parse(sa[i]); // string array --> byte array
        }
        return ba;
    }
}


