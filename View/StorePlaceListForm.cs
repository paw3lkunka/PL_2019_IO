using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Api.Controllers;
using Api.DTOs;
using Api.Enums;
using Model.Models;

namespace View
{
    public partial class StorePlaceListForm : Form
    {
        private readonly StorePlaceController _storePlaceController;
        private readonly StorePlaceAddEditForm _storePlaceAddEditForm;
        private StorePlacesDTO _storePlacesDTO;

        public StorePlaceListForm(StorePlaceController storePlaceController, StorePlaceAddEditForm storePlaceAddEditForm)
        {
            _storePlaceController = storePlaceController;
            _storePlaceAddEditForm = storePlaceAddEditForm;
            _storePlaceAddEditForm.FormClosed += delegate { SynchronizeStorePlaces(); };
            InitializeComponent();
        }

        private void StorePlaceListForm_Load(object sender, EventArgs e)
        {
            SynchronizeStorePlaces();
        }

        private void SynchronizeStorePlaces()
        {
            _storePlacesDTO = _storePlaceController.GetAllStorePlaces();
            listStorePlace.Items.Clear();

            switch(_storePlacesDTO.Status)
            {
                case CollectionGetStatus.Failure:
                    MessageBox.Show(
                        "Wystąpił problem z odczytem placówek z bazy danych. Skontatkuj się z administratorem usługi.",
                        "Błąd odczytu placówek",
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                    );

                    break;

                case CollectionGetStatus.Empty:

                    string[] info =
                    {
                        "---",
                        "Brak placówek do wyświetlenia",
                        "------"
                    };
                    listStorePlace.Items.Add(new ListViewItem(info));

                    break;

                case CollectionGetStatus.Success:

                    foreach(var sp in _storePlacesDTO.StorePlaces)
                    {
                        string[] storePlaceInfo =
                        {
                            sp.Id.ToString(),
                            sp.Name.ToString(),
                            sp.Type == 0 ? "Magazyn" : "Punkt wysyłki"
                        };

                        listStorePlace.Items.Add(new ListViewItem(storePlaceInfo));
                    }

                    break;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(listStorePlace.SelectedItems.Count >= 1)
            {
                var storePlace = _storePlacesDTO.StorePlaces[listStorePlace.SelectedItems[0].Index];

                _storePlaceAddEditForm.storePlace = storePlace;
                _storePlaceAddEditForm.ShowDialog();
            }

            EditDeleteButtonEnablement();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _storePlaceAddEditForm.storePlace = new StorePlace()
            {
                Type = -1,
            };
            _storePlaceAddEditForm.ShowDialog();

            EditDeleteButtonEnablement();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć wybraną placówkę z rejestru?", "Potwierdzenie", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (ListViewItem s in listStorePlace.SelectedItems)
                {
                    _storePlaceController.RemoveStoreplace(_storePlacesDTO.StorePlaces[listStorePlace.Items.IndexOf(s)].Id);
                }

                SynchronizeStorePlaces();
            }

            EditDeleteButtonEnablement();
        }

        private void listStorePlace_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EditDeleteButtonEnablement();
        }

        private void EditDeleteButtonEnablement()
        {
            var isStorePlaceSelected = listStorePlace.SelectedItems.Count == 1;

            editButton.Enabled = isStorePlaceSelected;
            removeButton.Enabled = isStorePlaceSelected;
        }
    }
}
