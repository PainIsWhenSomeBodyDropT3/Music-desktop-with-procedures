using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Music.util
{
    class SongValidation
    {
        private Dictionary<string, bool> pairs;
        private const string DESCRIPTION = "^.{1,1000}$";
        private const string AUTHOR_NAME = "^.{1,50}$";
        private const string ALBUM = "^.{1,50}$";

        public SongValidation()
        {
            pairs = new Dictionary<string, bool>();
            pairs.Add("MusicDescription", false);
            pairs.Add("AuthorName", false);
            pairs.Add("Date", false);
            pairs.Add("Album", false);
            pairs.Add("typeSong", false);
        }

        public bool descriptionValidation<T>(T elem) where T : TextBox
        {
            return validate(elem, elem.Text, DESCRIPTION);


        }
        public bool authorNameValidation<T>(T elem) where T : TextBox
        {
            return validate(elem, elem.Text, AUTHOR_NAME);
        }
        public bool albumValidation<T>(T elem) where T : TextBox
        {
            return validate(elem, elem.Text, ALBUM);
        }
        public void validateOthers<T>(T element) where T : Control
        {

            pairs[element.Name] = true;
        }
        private bool validate<T>(T element, string str, string srtRegex) where T : TextBox
        {
            Regex regex = new Regex(srtRegex);
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                pairs[element.Name] = true;
                element.Background = new SolidColorBrush(Color.FromArgb(90, 0, 254, 0));
                return true;
            }
            else
            {
                pairs[element.Name] = false;
                element.Background = new SolidColorBrush(Color.FromArgb(90, 254, 0, 0));
                return false;
            }
        }

        public bool isAllFieldValidate()
        {
            foreach (KeyValuePair<string, bool> keyValue in pairs)
            {
                if (!keyValue.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
