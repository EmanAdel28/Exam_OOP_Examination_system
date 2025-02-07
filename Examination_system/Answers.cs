using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_system
{
    internal struct Answers
    {
        #region Properties
        public int[] ID { get; set; }
        public string[] AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answers()
        {
            ID = new int[3];
            AnswerText = new string[3];
        }
        #endregion

        #region Indexer


        public string this[int id]
        {
            get
            {
                if (ID is not null && AnswerText is not null)
                {
                    for (int i = 0; i < ID.Length; i++)
                    {
                        if (id == ID[i])
                            return AnswerText[i];
                    }
                }
                return null;

            }

            set
            {
                if (ID is not null && AnswerText is not null)
                {
                    for (int i = 0; i < ID.Length; i++)
                    {
                        if (id == ID[i])
                        {
                            AnswerText[i] = value;
                            break;
                        }

                    }
                }


            }

        }


        #endregion

        #region Override ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ID.Length; i++)
            {
                sb.Append($"{ID[i]}: {AnswerText[i]}\n");
            }
            return sb.ToString();
        }
        #endregion
    }
}
