using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;

namespace MachineChess
{

    public class QuizExtension : MonoBehaviour
    {
        GameObject question;
        GameObject answer1;
        GameObject answer2;
        GameObject answer3;
        GameObject answer4;
        byte[] results;
        void Start()
        {
            print("Start");
            StartCoroutine(GetText());

            question = GameObject.Find("Canvas/QuizExtension/Question");
            answer1 = GameObject.Find("Canvas/QuizExtension/Answer1");
            answer2 = GameObject.Find("Canvas/QuizExtension/Answer2");
            answer3 = GameObject.Find("Canvas/QuizExtension/Answer3");
            answer4 = GameObject.Find("Canvas/QuizExtension/Answer4");
            Hide();
        }

        void Hide(){
            print("hide");
            gameObject.GetComponent<Image>().enabled = false;
            question.GetComponent<Text>().enabled = false;
            answer1.GetComponent<Text>().enabled = false;
            answer2.GetComponent<Text>().enabled = false;
            answer3.GetComponent<Text>().enabled = false;
            answer4.GetComponent<Text>().enabled = false;
        }
        void Show()
        {
            gameObject.GetComponent<Image>().enabled = true;
            question.GetComponent<Text>().enabled = true;
            answer1.GetComponent<Text>().enabled = true;
            answer2.GetComponent<Text>().enabled = true;
            answer3.GetComponent<Text>().enabled = true;
            answer4.GetComponent<Text>().enabled = true;
        }

        public bool Display(){
            Show();
            return false;
        }

        void Update()
        {
            if (Input.GetKeyDown("1"))
                Hide();
            if (Input.GetKeyDown("2"))
                Hide();
            if (Input.GetKeyDown("3"))
                Hide();
            if (Input.GetKeyDown("4"))
                Hide();

        }


        IEnumerator GetText()
        {
            UnityWebRequest www = UnityWebRequest.Get("https://api.quizlet.com/2.0/sets/262496621/terms?client_id=Cacnu2R3hb");

            //www.method = UnityWebRequest.kHttpVerbGET;
            //www.SetRequestHeader("Authorization", "Bearer BM78y2ZtRbhd8hrt4yhmZK");
            yield return www.SendWebRequest();
            /*
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            */

            //else
            //{
                // Show results as text
                Debug.Log(www.downloadHandler.text);

            //string[] text = Regex.Split((www.downloadHandler.text.Substring(1, www.downloadHandler.text.Length - 2), "},");
                        
            //ArrayList terms = new ArrayList();
            //foreach (string obj in text) {
            //    var tokens = Regex.Split(text, "..");
            //    print(obj.ToString());
            //    terms.Add(JsonUtility.FromJson<QuizletTerm>(obj));
            //}

                //// Or retrieve results as binary data
                //results = www.downloadHandler.data;
            //}
        }
    }

    public class QuizletTerm
    {
        public string term { get; set; }
        public string definition { get; set; }
    }

}