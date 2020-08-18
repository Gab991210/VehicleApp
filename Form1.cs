using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleApp
{
    public partial class frmVehicles : Form
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public frmVehicles()
        {
            InitializeComponent();
        }

        private void rbtnCar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCar.Checked)
            {
                grbCar.Enabled = true;
                grbBike.Enabled = false;
            }
            else
            {
                grbCar.Enabled = false;
                grbBike.Enabled = true;
            }
        }

        private void btnCreateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                Vehicle newVehicle;

                if (rbtnCar.Checked)
                {
                    newVehicle = new Car(txtName.Text,
                        txtBrand.Text,
                        double.Parse(txtPrice.Text),
                        int.Parse(txtWarranty.Text),
                        txtStore.Text,
                        cboFuel.Text,
                        (int)nrudPassenger.Value);
                }
                else
                {
                    newVehicle = new Bicycle(txtName.Text,
                        txtBrand.Text,
                        double.Parse(txtPrice.Text),
                        int.Parse(txtWarranty.Text),
                        txtStore.Text,
                        (int)nrudTireSize.Value,
                        cboTerrain.Text);
                }

                vehicles.Add(newVehicle);

                txtName.Text = "";
                txtBrand.Text = "";
                txtPrice.Text = "";
                txtWarranty.Text = "";
                txtStore.Text = "";

                cboFuel.Text = "";
                cboTerrain.Text = "";

                nrudPassenger.Value = 0;
                nrudTireSize.Value = 0;

                rbtnCar.Checked = true;

                MessageBox.Show($"Number of Vehicles: {vehicles.Count}");
            }
            catch (FormatException error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
