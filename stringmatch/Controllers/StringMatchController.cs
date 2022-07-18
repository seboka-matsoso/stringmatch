using Microsoft.AspNetCore.Mvc;

namespace stringmatch.Controllers
{
    public class StringMatchController : Controller
    {
        public string? Title { get; set; }

        //Summary //
        //A function that retrieves data from and returns it to the app view UI.
        //Get: /StringMatch/
        
        public IActionResult Index(string phrase)
        {
            this.Title = "String Match Application";
            

            if (!String.IsNullOrEmpty(phrase))
            {
                List<string> result = StringMatcher(phrase);
                string[] data = result.ToArray();

                ViewData["a"] = data[0];
                ViewData["e"] = data[1];
                ViewData["i"] = data[2];
                ViewData["o"] = data[3];
                ViewData["u"] = data[4];
            }
            return View("Index");
        }
        //Summary//
        //A function that handles the string input and returns the indecies of all vowels in the string phrase. 
        //Get: /StringMatch/StringMatcher/
        public List<string> StringMatcher(string phrase)
        {
            var firstVowelPositions = new System.Text.StringBuilder();
            var secondVowelPositions = new System.Text.StringBuilder();
            var thirdVowelPositions = new System.Text.StringBuilder();
            var fourthVowelPositions = new System.Text.StringBuilder();
            var lastVowelPositions = new System.Text.StringBuilder();
            
            List<string> result = new();
            
            int pos = 0;
            
            foreach (char c in phrase)
            {
                if(c == 'a')
                {
                    firstVowelPositions = firstVowelPositions.Append(pos.ToString()+",");
                    pos++;
                }
                else if (c == 'e')
                {
                    secondVowelPositions = secondVowelPositions.Append(pos.ToString() + ",");
                    pos++;
                }
                else if (c == 'i')
                {
                    thirdVowelPositions = thirdVowelPositions.Append(pos.ToString() + ",");
                    pos++;
                }
                else if (c == 'o')
                {
                    fourthVowelPositions = fourthVowelPositions.Append(pos.ToString() + ",");
                    pos++;
                }
                else if (c == 'u')
                {
                    lastVowelPositions = lastVowelPositions.Append(pos.ToString() + ",");
                    pos++;
                }
                else
                {
                    pos++;
                    //Sanitize output and get it ready to be returned back to calling context.
                    if(pos == (phrase.Length))
                    {
                        string firstVpos = "No Matches";
                        string secondVpos = "No Matches";
                        string thirdVpos = "No Matches";
                        string fourthVpos = "No Matches";
                        string lastVpos = "No Matches";

                        if (firstVowelPositions.Length > 0)
                        {
                            firstVpos = firstVowelPositions.ToString().TrimEnd(',');
                        }
                        if(secondVowelPositions.Length > 0) {
                            secondVpos = secondVowelPositions.ToString().TrimEnd(',');
                        }
                        if(thirdVowelPositions.Length > 0) {
                            thirdVpos = thirdVowelPositions.ToString().TrimEnd(',');
                        }
                        if(fourthVowelPositions.Length > 0) {
                            fourthVpos = fourthVowelPositions.ToString().TrimEnd(',');
                        }
                        if(lastVowelPositions.Length > 0) {
                            lastVpos = lastVowelPositions.ToString().TrimEnd(',');
                        }

                        result.Add(firstVpos);
                        result.Add(secondVpos);
                        result.Add(thirdVpos);
                        result.Add(fourthVpos);
                        result.Add(lastVpos);
                    }
                }
                
            }
            return result;
        }
    }
}
