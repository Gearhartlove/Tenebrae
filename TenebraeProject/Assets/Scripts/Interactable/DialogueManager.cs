using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class DialogueManager : MonoBehaviour
{
    int node_position = -1;
    DNode[] DNodeArray;
    DNode now_node;

    private void Start()
    {
        string[] lines = File.ReadAllLines(@"Assets/StoryBeats/dialogue1.txt");
        DNode[] DNodeArray = new DNode[100];
        

        //assign information into nodes
        for (int i = 0; i < lines.Length; i++)
        {
            //empty line

            if (lines[i] == "#newnode")
            {
                node_position++;
                DNodeArray[node_position] = new DNode();
                now_node = DNodeArray[node_position];
                
            }
            else if (lines[i].Length == 0) { Debug.Log("NewLine"); } //add to node sentence array
            else if (lines[i] == "#key") { now_node.key = Byte.Parse((lines[i]+1)); }
            else if (lines[i] == "#branch")
            {
                //seperate the branches, then put into branch array
                now_node.branches = SeperateBranches(lines[i]+1);
            }
            else if (lines[i] == "#sentences")
            {
                int idx = 0; //now_node sentence array index
                bool sentences = true; //false when at the next node 
                while (sentences)
                {
                    for (int k = i; k < lines.Length; i++)
                    {
                        if (lines[k].Length == 0) { idx++; }
                        else if (lines[k] == "#key") { sentences = false; i = k; break; } //TODO need to test
                        else { now_node.sentences[idx] = lines[k]; }
                    }
                }
                
            }
        }
    }

    private class DNode
    {
        public byte key;
        public byte[] branches = new byte[5];
        public string[] sentences = new string[100];
    }

    private byte[] SeperateBranches(string s)
    {
        string[] sa = s.Split(','); //string array
        byte[] ba = new byte[sa.Length]; //same size as previous array
        for (int i = 0; i < sa.Length; i++)
        {
            ba[i] = Byte.Parse(sa[i]); // string array --> byte array
        }
        return ba;
    }


}


