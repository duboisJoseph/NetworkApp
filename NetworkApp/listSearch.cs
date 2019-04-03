/* 
* This class simulates a table search algorithm to 
* detect if a file in the server is avaliable
*
* @author Joe Dubois, Alec Allain, Christian Yep, Anthony Nguyen
* @version 3/28/19
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace NetworkApp {

    public class listSearch {

        /* List of files in server */
        List<fileStruct> fileList;

        /* Keyword from user */
        string input;
        
        /* Constructor */
        public listSearch() {
            fileList = new List<fileStruct>();

        }

        /* 
        * This method finds files based on a keyword
        *
        * @param keyword is the user input
        * @param name is the server file list 
        */
        public void searchMethod(string keyword, List<fileStruct> fileList) {
            //fileList.Find(keyword);

            int listSize = fileList.Count;
            char[] characters = keyword.ToCharArray;
            int charSize = characters.Count;
            List<fileStruct> tempList = new List<fileStruct>();


            for (int i = 0; i < listSize; i++) {
                for (int j = 0; j < charSize; j++) {
                    if (fileList[i].ContainsAnyCase(characters[j])) {
                        tempList.Add(fileList[i]);
                    }
                }
            }

            int tempSize = tempList.Count;

            Console.WriteLine("Here are some similar characters:");

            for (int i = 0; i < tempSize; i++) {
                Console.WriteLine(tempList[i]);
            }
        }

        /* Main method */
        static void Main(string[] args) {

        }
    }
}