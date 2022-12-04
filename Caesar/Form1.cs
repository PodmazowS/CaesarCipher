namespace Caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(input_key.Text);
                string str_text = InputText.Text;
                string out_text = null;
                char[] AlphabetUpper = {'A','Ą','B','C','Ć','D','E','Ę','F','G','H','I','J','K','L','Ł','M','N','Ń','O',
                                        'Ó','P','Q','R','S','Ś','T','U','V', 'W','X','Y','Z','Ź','Ż' };

                char[] AlphabetLower ={'a','ą','b','c','ć','d','е','ę','f','g','h','i','j','k','l','ł','m','n','ń','o',
                                        'ó','p','q','r','s','ś','t','u','v','w','x','y','z','ź','ż'};


                char[] array_text = str_text.ToCharArray();
                for (int i = 0; i < array_text.Length; i++)
                {

                    if (array_text[i] == '!' || array_text[i] == ' ' || array_text[i] == '.' || array_text[i] == ',') out_text = out_text + array_text[i];


                    if (char.IsUpper(array_text[i]))
                    {

                        for (int j = 0; j < AlphabetUpper.Length; j++)


                            if (array_text[i] == AlphabetUpper[j])
                            {

                                try
                                {
                                    out_text = out_text + (char)AlphabetUpper[j + key];
                                }

                                catch
                                {
                                    out_text = out_text + (char)AlphabetUpper[j + key - 35];
                                }
                            }
                    }


                    if (char.IsLower(array_text[i]))
                    {
                        for (int j = 0; j < AlphabetLower.Length; j++)
                            if (array_text[i] == AlphabetLower[j])
                            {
                                try
                                {
                                    out_text = out_text + (char)AlphabetLower[j + key];
                                }
                                catch
                                {
                                    out_text = out_text + (char)AlphabetLower[j + key - 35];
                                }
                            }
                    }
                }




                OutputText.Text = out_text;
            }


            catch
            {
                OutputText.Text = "Proszę zapełnić wszystkie pola!";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
              InputText.Text = "";
              OutputText.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string arrStr = OutputText.Text;

            int max = 0; // największa liczba wystąpień danej litery to 1
            int max2 = 0; // liczba wystąpień określonej litery w jednym przejściu przez cykl

            char letter = 'a'; // najczęstszą literą jest 1
            char letter2; // najczęstszą literą jest 2

            // wyszukuje literę, która występuje najczęściej w tekście
            for (int j = 0; j < arrStr.Length; j++)
            {
                letter2 = arrStr[j];
                for (int i = 0; i < arrStr.Length; i++)
                {
                    if (Char.IsLetter(arrStr[i]) && arrStr[i] == letter2)
                        max2 += 1;
                }
                if (max2 > max)
                {
                    max = max2;
                    letter = letter2;
                }
                max2 = 0;
            }

            // alphabet (35 liter)
            string arrAbc = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";

            int c1 = arrAbc.IndexOf('a'); // pozycja litery a, która występuje najczęściej
            int c2 = 0; // indeks alfabetyczny najczęściej występującego elementu

            // wyszukaj indeks w alfabecie litery, która występuje najczęściej
            for (int i = 0; i < arrAbc.Length; i++)
            {
                if (arrAbc[i] == letter)
                {
                    c2 = i;
                }
            }

            // obliczenie wartości przemieszczenia
            int sh = (c1 - c2) % 35;
            if (sh < 0)
            {
                sh = sh * (-1);
            }

            string res = "";

            // dekodowanie zaszyfrowanego tekstu ze znanym krokiem
            for (int i = 0; i < arrStr.Length; i++)
            {
                if (!Char.IsLetter(arrStr[i]))
                {
                    res += arrStr[i];
                }
                else
                {
                    int position = arrAbc.IndexOf(arrStr[i]) - sh;
                    if (position < 0)
                    {
                        position += arrAbc.Length;
                    }
                    res += arrAbc[position];
                }
            }
            InputText.Text = res;

        }
    }
    }
