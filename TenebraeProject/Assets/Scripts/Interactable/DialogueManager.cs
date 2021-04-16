using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using System;

//TODO portrait code logic
public class DialogueManager : MonoBehaviour
{
    //foundation
    private DNode[] DNodeArray;
    private DNode now_node;

    //node + setence heirarchy/organization in .txt file
    int node_position = -1;
    int node_idx = 0;
    int sent_idx = 0;
    const string skip =
        "#---------------------------------------------------------------------------";
    //Portrait Logic
    [SerializeField] private Animator charPortrait;
    [SerializeField] private Animator npcPortrait;

    //Continue + Choice Dialogue objects
    [SerializeField]
    private TMPro.TextMeshProUGUI ContinueText;
    [SerializeField]
    private GameObject[] Choices;

    private void Start()
    {
        string[] lines = File.ReadAllLines(@"Assets/StoryBeats/dialogue1.txt");
        DNodeArray = new DNode[100];
        Choices = new GameObject[4];
        SortInformation(lines);
        foreach (DNode d in DNodeArray)
        {
            //Debug.Log(d?.isEndNode);
        }
    }

    //Node Subclass
    private class DNode
    {
        public byte key;
        public bool isChoiceNode = false;
        public bool isEndNode = false;
        public byte[] branches = new byte[4];
        public string[] sentences = new string[100];
        public string person;
        public string speaker;
    }

    private void SortInformation(string[] lines)
    {
        //assign information into nodes
        for (int i = 0; i < lines.Length; i++)
        {
            switch (lines[i])
            {
                case "#newnode":
                    node_position++; //starts at -1
                    DNodeArray[node_position] = new DNode();
                    now_node = DNodeArray[node_position];
                    break;
                case "#key":
                    now_node.key = Byte.Parse((lines[i + 1]));
                    break;
                case "#branch":
                    //TODO end dialogue with -1 branch idea
                    if (lines[i + 1] != "end")
                    {
                        now_node.branches = SeperateBranches(lines[i + 1]);
                    }
                    else { now_node.isEndNode = true; }
                    break;
                case "#sentences":
                    int sent_idx = 0; //now_node sentence array index
                    bool sentences = true; //false when at the next node 
                    while (sentences)
                    {
                        for (int k = i+1; k < lines.Length; k++)
                        {
                            if (lines[k].Length == 0) { sent_idx++; }
                            //minus two because i is incredmented after the break
                            //needs to see the "#newline" and the next line after
                            else if (lines[k] == "#key" || lines[k] == skip)
                            { sentences = false; sent_idx = 0; i = k - 2; break; }
                            else { now_node.sentences[sent_idx] += lines[k]; }
                        }
                    }
                    break;
                case "#speaker":
                    now_node.speaker = lines[i + 1];
                    break;
                case skip: //used to seperate the nodes
                    continue;
            }
        }
    }

    //Comma seperate branches
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

    /*called by the NPC when in range for the first time*/
    public void StartDialogue()
    {
        PortraitTalking(DNodeArray[node_idx]);
        ContinueText.text = DNodeArray[node_idx].sentences[sent_idx];  
    }

    /*called by the NPC when leaving range for the first time */
    public void StopDialogue()
    {
        PortraitTalking(); //nobody talking
    }
    public void ContinueDialogue()
    {
        //base case
        if (DNodeArray[node_idx].isEndNode)
        {
            ContinueText.text = DNodeArray[node_idx].sentences[sent_idx];
        }
        else 
        {
            sent_idx++;
            //go to next sentence
            //if next sentence does not exist go to the next node
            if (DNodeArray[node_idx].sentences[sent_idx] == null)
            {
                node_idx++; sent_idx = 0;
                PortraitTalking(DNodeArray[node_idx]);
            }
            ContinueText.text = DNodeArray[node_idx].sentences[sent_idx];
        }
    }

    /*method below used for popping up and down the portraits that are talking
     * by setting the bool "isTalking" attatched to the DialoguePortraitaAnim
     * Animator to true (talking, illuminated), and false (not talking, black)
    */
    private void PortraitTalking(DNode node)
    {
        if (node.speaker == "Tenebrae") //Tenebrae == main character name
        {
            charPortrait.SetBool("isTalking", true);
            npcPortrait.SetBool("isTalking", false);
        }
        else
        {
            npcPortrait.SetBool("isTalking", true);
            charPortrait.SetBool("isTalking", false);
        }
    }

    /* Neither of the speakers are speaking (leave the range)*/
    private void PortraitTalking()
    {
        charPortrait.SetBool("isTalking", false);
        npcPortrait.SetBool("isTalking", false);
    }
}


