using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace Mini2
{
    public partial class Form1 : Form
    {
        private string currentRootPath = "";
        private const string SettingsFile = "last_path.txt";

        public Form1()
        {
            InitializeComponent();
            txtFileContent.Visible = false;
            pictureBox1.Visible = false;
            lblStatus.Text = "";

            LoadLastPath();
        }

        private void txtFileContent_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selectează un director";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    errorProvider1.Clear();
                    currentRootPath = dlg.SelectedPath;
                    LoadTreeView(currentRootPath);
                    SaveLastPath(currentRootPath);
                }
                else
                {
                    if (string.IsNullOrEmpty(currentRootPath))
                        errorProvider1.SetError(btnBrowse, "Niciun director selectat!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentRootPath))
                LoadTreeView(currentRootPath);
        }

        private void LoadTreeView(string path)
        {
            treeView1.Nodes.Clear();
            ClearPreview();

            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(path);
                TreeNode rootNode = new TreeNode(rootDir.Name);
                rootNode.Tag = rootDir.FullName;
                LoadDirectoryRecursive(rootNode, rootDir);
                treeView1.Nodes.Add(rootNode);
                rootNode.Expand();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Acces refuzat: " + path, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDirectoryRecursive(TreeNode parentNode, DirectoryInfo dir)
        {
            // Subdirectoare
            try
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeNode dirNode = new TreeNode(subDir.Name);
                    dirNode.Tag = subDir.FullName;
                    LoadDirectoryRecursive(dirNode, subDir);
                    parentNode.Nodes.Add(dirNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                parentNode.Nodes.Add(new TreeNode("[Acces Refuzat]"));
            }
            catch (Exception ex)
            {
                parentNode.Nodes.Add(new TreeNode("[Eroare: " + ex.Message + "]"));
            }

            try
            {
                string[] allowed = { ".txt", ".png", ".jpg", ".jpeg", ".bmp" };

                foreach (FileInfo file in dir.GetFiles())
                {
                    string ext = file.Extension.ToLower();
                    if (Array.Exists(allowed, a => a == ext))
                    {
                        TreeNode fileNode = new TreeNode(file.Name);
                        fileNode.Tag = file.FullName;
                        parentNode.Nodes.Add(fileNode);
                    }
                }
            }
            catch (Exception ex)
            {
                parentNode.Nodes.Add(new TreeNode("[Eroare fișier: " + ex.Message + "]"));
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag as string;
            if (string.IsNullOrEmpty(path)) return;

            ClearPreview();

            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                string ext = fi.Extension.ToLower();

                lblStatus.Text = $"Nume: {fi.Name}  |  Extensie: {fi.Extension}  |  Dimensiune: {fi.Length} bytes";

                try
                {
                    if (ext == ".txt")
                    {
                        txtFileContent.Text = File.ReadAllText(path);
                        txtFileContent.Visible = true;
                    }
                    else if (ext == ".png" || ext == ".jpg" ||
                             ext == ".jpeg" || ext == ".bmp")
                    {
                        pictureBox1.Image = Image.FromFile(path);
                        pictureBox1.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nu pot deschide fișierul: " + ex.Message,
                        "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (Directory.Exists(path))
            {
                lblStatus.Text = "Director: " + path;
            }
        }

        private void ClearPreview()
        {
            txtFileContent.Visible = false;
            txtFileContent.Text = "";

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            pictureBox1.Visible = false;

            lblStatus.Text = "";
        }

        private void SaveLastPath(string path)
        {
            try { File.WriteAllText(SettingsFile, path); }
            catch { }
        }

        private void LoadLastPath()
        {
            try
            {
                if (File.Exists(SettingsFile))
                {
                    string saved = File.ReadAllText(SettingsFile).Trim();
                    if (Directory.Exists(saved))
                    {
                        currentRootPath = saved;
                        LoadTreeView(currentRootPath);
                    }
                }
            }
            catch { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
