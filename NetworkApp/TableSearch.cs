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

    class TableSearch {

        /* File identification number */
        int ID;

        /* File name */
        string fileName;

        /* File description */
        string desc{set; get;}

        /* File owner's identification */
        int hostID{set; get;}

        /* Contains file names */
        List<string> fileList;

        /* Constructor */
        public TableSearch() {
            fileList = new List<string>();
        }

        /*  
        * Method that searches through entire "table" and
        * finds corresponding names
        *
        * @param name is the filelist to be searched
        */
        private void searchList(string name, List<string> holdingList) {
            int size = holdingList.Count;

            for (int i = 0; i < size; i++) {
                if (name == holdingList[i]) {
                    Console.WriteLine("The file " + name + " has been found");
                }
            }

        }

        /* Main method used for testing purposes */
        static void Main(string[] args) {

            string input;

            TableSearch holding = new TableSearch();
            holding.fileList.Add("Somefile.txt");
            holding.fileList.Add("Sample1.png");
            holding.fileList.Add("Anniversary.txt");
            holding.fileList.Add("Sample324.gif");


            Console.WriteLine("Please enter file name: ");
            input = Console.ReadLine();

            Console.WriteLine("Searching for a file with the name " + input);

            holding.searchList(input, holding.fileList);
        }

    }

}