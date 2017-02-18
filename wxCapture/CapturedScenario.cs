using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxCore;
using System.Windows.Forms;

namespace wxCapture
{
    internal class CapturedScenario
    {
        wxScenario scenario;
        bool initialized = false;

        internal void Clear()
        { 
            scenario = new wxScenario();
            initialized = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        internal void Initialize(HtmlDocument doc)
        {
            scenario = new wxScenario();
            scenario.Name = doc.Title;
            scenario.StartUrl = doc.Url.ToString();
            scenario.ConnectionString = "";
            initialized = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="tv"></param>
        internal void CapturePage(HtmlDocument document, TreeView tv)
        {
            if (!initialized)
                Initialize(document);
            wxPage page = new wxPage();
            page.Name = document.Title;
            wxTsSimple test = new wxTsSimple();
            wxTsSimple linkTest = new wxTsSimple();
            linkTest.Name = "Captured Links";
            test.Name = "Captured Html Elements";
            TreeNode tnPage = new TreeNode(page.ToString());
            tnPage.Tag = page;
            TreeNode tnTest = new TreeNode(test.ToString());
            tnTest.Tag = test;
            TreeNode tnTestLnk = new TreeNode(linkTest.ToString());
            tnTestLnk.Tag = linkTest;
            foreach (HtmlElement element in document.All)
            {
                wxAction action = WxFactory.GetWxAction(element);
                if (action != null)
                {
                    TreeNode tnAction = new TreeNode(action.ToString());
                    tnAction.Tag = action;
                    if (action is wxActLink)
                    {
                        linkTest.AddAction(action);
                        tnTestLnk.Nodes.Add(tnAction);
                    }
                    else
                    {
                        test.AddAction(action);
                        tnTest.Nodes.Add(tnAction);
                    }
                }
            }
            // Add tests
            tnPage.Nodes.Add(tnTest);
            page.AddTest(test);
            // Add link tests
            tnPage.Nodes.Add(tnTestLnk);
            page.AddTest(linkTest);
            // Add page
            tv.Nodes.Add(tnPage);
            scenario.Pages.Add(page);            
        }
        /// <summary>
        /// Remove TreeNode and associated event
        /// </summary>
        /// <param name="treeNode"></param>
        internal void Remove(TreeNode treeNode, TreeView tvTests)
        {
            if (treeNode.Tag is wxPage)
            {
                wxPage p = treeNode.Tag as wxPage;
                scenario.Pages.Remove(p);
            }
            else if (treeNode.Tag is wxTest)
            {
                wxTest t = treeNode.Tag as wxTest;
                scenario.Pages[0].Tests.Remove(t);
            }
            else if (treeNode.Tag is wxAction)
            {
                wxTest t = treeNode.Parent.Tag as wxTest;
                if (t != null)
                {
                    wxAction a = treeNode.Tag as wxAction;
                    t.Actions.Remove(a);
                }
            }
            else
                throw new ApplicationException("Not able to remove thang");
            // If everything is ok, remove 
            tvTests.Nodes.Remove(treeNode);
        }

        internal void RemoveAllBut(TreeNode treeNode, TreeView tvTests)
        {
            if (treeNode.Tag is wxPage)
            {
                wxBasePage page = treeNode.Tag as wxBasePage;
                for (int i = scenario.Pages.Count-1; i >= 0; i--)
                {
                    if (page != scenario.Pages[i])
                        scenario.Pages.RemoveAt(i);
                }
                for (int i = tvTests.Nodes.Count-1; i >= 0; i--)
                {
                    if (treeNode != tvTests.Nodes[i])
                        tvTests.Nodes.Remove(tvTests.Nodes[i]);
                }
            }
            else if (treeNode.Tag is wxTest)
            {
                return; // cuz we will always have only one test per page (in recorder)
                //wxTest test = treeNode.Tag as wxTest;
                //wxBasePage page = treeNode.Parent.Tag as wxBasePage;
                //for (int i = scenario.Pages.Count - 1; i >= 0; i--)
                //{
                //    if (page != scenario.Pages[i])
                //        scenario.Pages.RemoveAt(i);
                //}
                //for (int i = tvTests.Nodes.Count - 1; i >= 0; i--)
                //{
                //    if (treeNode != tvTests.Nodes[i])
                //        tvTests.Nodes.Remove(tvTests.Nodes[i]);
                //}
            }
            else if (treeNode.Tag is wxAction)
            {
                wxAction a = treeNode.Tag as wxAction;
                wxTest t = treeNode.Parent.Tag as wxTest;
                for (int i = t.Actions.Count - 1; i >= 0; i--)
                {
                    if (t.Actions[i] != a)
                        t.Actions.RemoveAt(i);
                }
                for (int i = treeNode.Parent.Nodes.Count - 1; i >= 0; i--)
                {
                    if (treeNode != treeNode.Parent.Nodes[i])
                        treeNode.Parent.Nodes.RemoveAt(i);
                }
            }
            else
                throw new ApplicationException("Not able to remove thang");
        }

        internal void Export(string fileName)
        {
            WxSerialize.Serialize(fileName, scenario);
        }
    }
}

