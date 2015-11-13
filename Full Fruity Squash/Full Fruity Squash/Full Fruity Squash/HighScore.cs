using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Full_Fruity_Squash
{
    public class HighScore
    {
        private string filename = ("FullFruitySquash.txt");
        private List<PersonDetails> TopFivePeople = new List<PersonDetails>();

        public List<PersonDetails> GetSetTopFivePeople
        {
            get { return TopFivePeople; }
            set { TopFivePeople = value; }
        }

        public HighScore() // Constructor
        {
           
        }

        public bool LoadPeople() // Load people from text file
        {
            TopFivePeople.Clear();
            System.IO.TextReader TextIn = null;
            try
            {
                TextIn = new System.IO.StreamReader(filename);

                int NumberOfPerson = int.Parse(TextIn.ReadLine());
                for (int i = 0; i < NumberOfPerson; i++) // Load all the high score people
                {
                    string PersonName = TextIn.ReadLine();
                    int Score = int.Parse(TextIn.ReadLine());
                    TopFivePeople.Add(new PersonDetails(PersonName, Score));
                }
                
            }
            catch
            {
                return false;
            }
            finally
            {
                if (TextIn != null) TextIn.Close();
            }
            return true;
        }

        public bool SavePeople() // Save people from text file
        {
            System.IO.TextWriter textOut = null;
            try
            {

                textOut = new System.IO.StreamWriter(filename);
                textOut.WriteLine(TopFivePeople.Count());
                foreach (PersonDetails People in TopFivePeople) // Save all the people
                {
                    textOut.WriteLine(People.NameGetSet);
                    textOut.WriteLine(People.ScoreGetSet);
                }

            }
            catch
            {
                return false;
            }
            finally
            {
                if (textOut != null) textOut.Close();
            }

            return true;
        }

    }

    public class PersonDetails
    {
        public PersonDetails(string InName, int INScore)
        {
            Name = InName;
            Score = INScore;
        }

        private string Name;

        public string NameGetSet
        {
            get{return Name;}
            set { Name = value; }
        }

        private int Score;

        public int ScoreGetSet
        {
            get { return Score; }
            set{ Score = value; }
        }
    }

}
