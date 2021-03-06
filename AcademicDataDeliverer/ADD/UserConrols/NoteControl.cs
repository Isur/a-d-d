﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace ADD.UserConrols
{
    public partial class NoteControl : UserControl, Views.INoteView
    {
        #region FIELDS & PROPERTIES
        IViewChanger viewChanger;

       
        #endregion
        #region CONSTRUCTOR
        public NoteControl(IViewChanger viewChanger)
        {
            InitializeComponent();
            this.viewChanger = viewChanger;
        }
        #endregion

        #region INTERFACE
        public event Func<ICollection<College>> CollegeGetItems;
        public event Func<string, ICollection<Faculty>> FacultyGetItems;
        public event Func<string, ICollection<Specialization>> SpecializationsGetItems;
        public event Func<string, ICollection<Subject>> SubjectGetItems;
        public event Func<string, ICollection<Material>> MaterialGetItems;
        public event Func<string, string, bool> SaveToFile;
        #endregion

        #region PUBLIC

        #endregion

        #region PRIVATE

        #endregion


        private async void NoteControl_Load(object sender, EventArgs e)
        {
            loadingProgressBar.Visible = true;

            var task = new Task<ICollection<College>>(() =>
            {
                return CollegeGetItems.Invoke();
            });
            task.Start();

            var colleges = await task;

            foreach (var college in colleges)
            {
                TreeNode nodeCollege = treeViewNotes.Nodes.Add(college.Name);
                var taskFac = new Task<ICollection<Faculty>>(() => { return FacultyGetItems.Invoke(college.Name); });
                taskFac.Start();

                var faculties = await taskFac;
                foreach(var faculty in faculties)
                {
                    TreeNode nodeFaculty = nodeCollege.Nodes.Add(faculty.Name);
                    var taskSpec = new Task<ICollection<Specialization>>(() => { return SpecializationsGetItems.Invoke(faculty.Name); });
                    taskSpec.Start();

                    var specializations = await taskSpec;
                    if(specializations.Count < 1)
                    {
                        treeViewNotes.Nodes.Remove(nodeFaculty);
                    }
                    foreach (var specialization in specializations)
                    {
                        TreeNode nodeSpecialization = nodeFaculty.Nodes.Add(specialization.Name);
                        var taskSubject = new Task<ICollection<Subject>>(() => { return SubjectGetItems.Invoke(specialization.Name); });
                        taskSubject.Start();

                        var subjects = await taskSubject;
                        foreach (var subject in subjects)
                        {
                            TreeNode nodeSubject = nodeSpecialization.Nodes.Add(subject.Name);
                            var taskMaterial = new Task<ICollection<Material>>(() => { return MaterialGetItems.Invoke(subject.Name); });
                            taskMaterial.Start();

                            var materials = await taskMaterial;
                            foreach (var material in materials)
                            {
                                TreeNode nodeMats = nodeSubject.Nodes.Add(material.Title);
                                nodeMats.Tag = material;
                            }

                        }
                    }
                }
            }

            loadingProgressBar.Visible = false;
        }

        private void treeViewNotes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag is Material)
            {
                try
                {
                    richTextBoxNote.Text = MaterialsRepository.GetDetailsByID((e.Node.Tag as Material).Id).Content;
                }
                catch(Exception)
                {
                    MessageBox.Show(Properties.Resources.ConnectionProblem);
                }
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            viewChanger.ShowLoginView();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            viewChanger.ShowProfileView();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog selectLocation = new SaveFileDialog();
            selectLocation.Filter = "txt files (*.txt)|*.txt";
            string toSave = richTextBoxNote.Text;
            if(toSave == "")
            {
                MessageBox.Show("Wybierz notatkę, która nie jest pusta!");
                return;
            }
            DialogResult dial = selectLocation.ShowDialog();
            if (dial == DialogResult.Cancel)
                return;
            if (selectLocation.FileName != "" && toSave != "")
            {
                saveToFile(selectLocation.FileName, toSave);
            }
            else if (selectLocation.FileName == "")
                MessageBox.Show("Wybierz miesjce zapisu!");
            else
                MessageBox.Show("Wybierz notatkę, która nie jest pusta!");
        }
        private async void saveToFile(string path, string contnent)
        {
            var task = new Task<bool>(() => {
                return SaveToFile(path, contnent);
            });
            task.Start();
            bool saved = await task;
            if (saved)
                MessageBox.Show("Zapisano!");
            else
                MessageBox.Show("Nie udało się zapisać!");
        }
    }
}
