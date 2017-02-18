using System;
using System.Collections.Generic;
using System.Text;
using WatiN.Core;
using System.Xml.Serialization;

namespace wxCore
{
    /// <summary>
    /// Test to finish a Questionnaire. Fills the fields with "dummy" values
    /// </summary>
    [XmlType(TypeName = "wxTsQuestionnaire")]
    public class wxTsQuestionnaire : wxTest
    {
        /// <summary>
        /// The action to submit pages (button, form)
        /// </summary>
        [XmlElement]
        public wxAction submitAction;
        /// <summary>
        /// The dummy value to fill the text fields
        /// </summary>
        [XmlElement]
        public string TextFiller = "1";
        /// <summary>
        /// The text to determine when we finish the test
        /// </summary>
        [XmlElement]
        public string FinishText = "Congratulations";
        /// <summary>
        /// The text to identify that we have required elements with no valid input
        /// </summary>
        [XmlElement]
        public string UnfinishedText = "You still have unanswered questions or invalid answers";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Test()
        {
            if (submitAction == null)
            {
                Wxs.Instance.Log.Error("Null submit action, will not execute test");
                return false;
            }
            // Submit Form
            submitAction.Do(Wxs.Instance.Ie);
            //Wxs.Instance.Ie.Forms[0].Submit();
            // check if we are done, if not, 
            if (!Wxs.Instance.Ie.ContainsText(FinishText))
            {
                if (Wxs.Instance.Ie.ContainsText(UnfinishedText))
                    CompleteForm();
                Test();
            }
            return true;
        }

        /// <summary>
        /// Find (not hidden) empty Text Fields and inserts a "dummy" value on
        /// them, so we can go to next page
        /// </summary>
        void FillTextBoxes()
        {
            foreach (TextField t in Wxs.Instance.Ie.TextFields)
            {
                Name = t.GetAttributeValue("name");
                // weed out the hidden ones
                if (!t.OuterHtml.Contains("hidden"))
                {
                    if (t.Text == null)
                    {
                        Wxs.Instance.Log.Info(String.Format("Filling text field [{0}] with text {1}", t.Name, TextFiller));
                        t.AppendText(TextFiller);
                    }
                }
            }
        }
        /// <summary>
        /// Gathers the check boxes on current page and groups them using the 
        /// fact that (in out code) the name is the same for group members, 
        /// only ID differs
        /// </summary>
        void FillEmptyCheckBoxes()
        {
            
            Dictionary<string, List<CheckBox>> checks = new Dictionary<string, List<CheckBox>>();
            foreach (CheckBox c in Wxs.Instance.Ie.CheckBoxes)
            {
                bool checkeds = c.Checked;
                Name = c.GetAttributeValue("name");
                if (checks.ContainsKey(Name))
                {
                    checks[Name].Add(c);
                }
                else
                {
                    List<CheckBox> lst = new List<CheckBox>();
                    lst.Add(c);
                    checks.Add(Name, lst);
                }
            }
            Wxs.Instance.Log.Debug(String.Format("All Check groups # {0}", checks.Count));

            foreach (KeyValuePair<string, List<CheckBox>> kvp in checks)
            {
                bool noneChecked = true;
                foreach (CheckBox c in kvp.Value)
                {
                    // Find if one on the group is checked
                    if (c.Checked)
                    {
                        noneChecked = false;
                        continue;
                    }
                }
                if (noneChecked) // then check the first one ... 
                {
                    Wxs.Instance.Log.Info(String.Format("Checking checkbox ID = {0}", kvp.Value[0].Id));
                    kvp.Value[0].Checked = true;
                }
            }
        }
        /// <summary>
        /// Gathers the radio buttons on current page and groups them using the 
        /// fact that (in out code) the name is the same for group members, 
        /// only ID differs 
        /// </summary>
        void FillEmptyRadios()
        {
            // Construct radio dictionary
            Dictionary<string, List<RadioButton>> radios = new Dictionary<string, List<RadioButton>>();
            foreach (RadioButton r in Wxs.Instance.Ie.RadioButtons)
            {
                //title = r.Title;
                Name = r.GetAttributeValue("Name");
                //id = r.Id;
                //innerHtml = r.InnerHtml;
                if (!radios.ContainsKey(Name))
                {
                    List<RadioButton> lst = new List<RadioButton>();
                    lst.Add(r);
                    radios.Add(Name, lst);
                }
                else
                {
                    radios[Name].Add(r);
                }
            }
            // Find empty groups and click on first group member
            foreach (KeyValuePair<string, List<RadioButton>> kvp in radios)
            {
                bool noneChecked = true;
                foreach (RadioButton r in kvp.Value)
                {
                    // Find if one on the group is checked
                    if (r.Checked)
                    {
                        noneChecked = false;
                        continue;
                    }
                }
                if (noneChecked) // then check the first one ... 
                {
                    Wxs.Instance.Log.Info(String.Format("Checking Radio ID = {0}", kvp.Value[0].Id));
                    kvp.Value[0].Click(); //
                }
            }
        }
   
    
        /// <summary>
        /// Fills empty radio groups, empty checkbox groups and 
        /// empty text boxes
        /// </summary>
        private void CompleteForm()
        {
            FillEmptyRadios();
            //FillEmptyCheckBoxes();
            FillTextBoxes();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Questionnaire {0} with filler {1}", Name, TextFiller);
        }
    }
}
