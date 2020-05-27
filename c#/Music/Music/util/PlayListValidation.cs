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
    class PlayListValidation
    {
        private Dictionary<string, bool> pairs;
        private const string NAME = "^.{1,200}$";
        private const string PASSWORD = "^.{1,1000}$";

        public PlayListValidation()
        {
            pairs = new Dictionary<string, bool>();
            pairs.Add("Name", false);
            pairs.Add("Description", false);


        }

        public bool playListNameValidation<T>(T elem) where T : TextBox
        {
            return validate(elem, elem.Text, NAME);


        }
        public bool playListDescriptionValidation<T>(T elem) where T : TextBox
        {
            return validate(elem, elem.Text, PASSWORD);
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
