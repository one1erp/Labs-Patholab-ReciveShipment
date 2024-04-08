using LSExtensionWindowLib;
using LSSERVICEPROVIDERLib;
using Patholab_Common;
using Patholab_DAL_V1;
using Patholab_XmlService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using UserControl = System.Windows.Forms.UserControl;


namespace ReciveShipment
{


    [ComVisible(true)]
    [ProgId("ReciveShipment.ReciveShipmentCls")]
    public partial class ReciveShipmentCls : UserControl, IExtensionWindow
    {

        #region Private fields

        private INautilusProcessXML xmlProcessor;
        private IExtensionWindowSite2 _ntlsSite;
        private INautilusServiceProvider sp;
        private INautilusDBConnection _ntlsCon;
        public List<U_CLINIC> Clinics { get; set; }
        public List<PHRASE_ENTRY> SampleTypes { get; set; }

        private const string errMsg = ".כמות צנצנות חייבת להיות גדולה או שווה לכמות ההפניות";
        private const string bigUrg_errMsg = ".כמות דחופים או גדולים לא יכולה להיות גדולה מכמות ההפניות";
        private DataLayer dal;
        public bool DEBUG;
        private List<U_CONTAINER_USER> shipmentslist;
        private string mboxHeader = "קבלת משלוחים";

        #region Column names

        //   private const string SDG_COL = "sdgNum";
        private const string SAMPLES_COL = "SamplesNum";
        private const string clinicCol = "clinicsName";
        private const string BIG_COL = "bigQnt";
        private const string URGENT_COL = "urgentQnt";
        private const string SAMPLETYPE_COL = "sampleType";

        #endregion



        #endregion

        #region Ctor

        public ReciveShipmentCls()
        {
            InitializeComponent();
            BackColor = Color.FromName("Control");
            this.Dock = DockStyle.Fill;

            radButton1.ButtonElement.ToolTipText = "Add new row";
        }

        #endregion



        #region Implementation of IExtensionWindow

        public bool CloseQuery()
        {
            if (dal != null) dal.Close();
            this.Dispose();
            return true;
        }

        public void Internationalise()
        {
        }

        public void SetSite(object site)
        {
            _ntlsSite = (IExtensionWindowSite2)site;

            _ntlsSite.SetWindowInternalName("ReciveShipment");
            _ntlsSite.SetWindowRegistryName("ReciveShipment");
            _ntlsSite.SetWindowTitle("קבלת משלוחים");
        }




        public void PreDisplay()
        {

            xmlProcessor = Utils.GetXmlProcessor(sp);

            Utils.GetNautilusUser(sp);

            InitializeData();
        }

        public WindowButtonsType GetButtons()
        {
            return LSExtensionWindowLib.WindowButtonsType.windowButtonsNone;
        }

        public bool SaveData()
        {
            return false;
        }

        public void SetServiceProvider(object serviceProvider)
        {
            sp = serviceProvider as NautilusServiceProvider;
            _ntlsCon = Utils.GetNtlsCon(sp);

        }

        public void SetParameters(string parameters)
        {

        }

        public void Setup()
        {

        }

        public WindowRefreshType DataChange()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public WindowRefreshType ViewRefresh()
        {
            return LSExtensionWindowLib.WindowRefreshType.windowRefreshNone;
        }

        public void refresh()
        {
        }

        public void SaveSettings(int hKey)
        {
        }

        public void RestoreSettings(int hKey)
        {
        }

        public void Close()
        {

        }

        #endregion


        #region Initilaize

        public void InitializeData()
        {


            //    Debugger.Launch();
            try
            {
                dal = new DataLayer();

                if (DEBUG)
                    dal.MockConnect();
                else
                    dal.Connect(_ntlsCon);

                this.Clinics = dal.FindBy<U_CLINIC>(c => c.U_CLINIC_USER.U_SENDER == "T").ToList();
                this.SampleTypes = dal.GetPhraseByName("Container Sample Type").PHRASE_ENTRY.OrderBy(X => X.ORDER_NUMBER).ToList();

                BuildColumns(gridShipments);


            }
            catch (Exception e)
            {


                MessageBox.Show("Error in  InitializeData " + "/n" + e.Message, mboxHeader);
                Logger.WriteLogFile(e);
            }

        }

        public void InitilaizeGrid()
        {

            try
            {


                var dt = DateTime.Now.Date;
                gridShipments.Rows.Clear();
                gridShipments.Columns.Clear();
                BuildColumns(gridShipments);
                txtAssutaReq.Text = string.Empty;
                txtAssutaReq.Focus();

                //       shipmentslist.Clear();
                return;
                shipmentslist =
                    dal.GetAll<U_CONTAINER_USER>()
                       .Where(x => x.U_RECEIVED_ON > dt)
                       .OrderBy(x => x.U_CONTAINER_ID)
                       .ToList();



                PopulateData(shipmentslist);

            }
            catch (Exception e)
            {


                MessageBox.Show("Error in  InitializeData " + "/n" + e.Message, mboxHeader);
                Logger.WriteLogFile(e);
            }
        }

        private void PopulateData(List<U_CONTAINER_USER> shipmentslist)
        {
            // Debugger.Launch();
            foreach (U_CONTAINER_USER shipmentUser in shipmentslist)
            {
                //var shipmentUser = shipment.U_CONTAINER_USER;
                GridViewRowInfo newRow = gridShipments.Rows.AddNew();

                newRow.Cells["AutoIncrement"].Value = gridShipments.Rows.Count;

                newRow.Cells["ID"].Value = shipmentUser.U_CONTAINER_ID;

                newRow.Cells["Comments"].Value = shipmentUser.U_CONTAINER.DESCRIPTION;



                newRow.Cells["Receive_Number"].Value = shipmentUser.U_RECEIVE_NUMBER;

                newRow.Cells["Send_On"].Value = shipmentUser.U_SEND_ON;

                //  newRow.Cells[SDG_COL].Value = shipmentUser.U_NUMBER_OF_ORDERS;

                newRow.Cells[SAMPLES_COL].Value = shipmentUser.U_NUMBER_OF_SAMPLES;

                newRow.Cells[BIG_COL].Value = shipmentUser.U_BIG_QNT;

                newRow.Cells[URGENT_COL].Value = shipmentUser.U_URGENT_QNT;

                if (shipmentUser.U_SAMPLE_TYPE != null)
                {
                    var st = SampleTypes.FirstOrDefault(x => x.PHRASE_NAME == shipmentUser.U_SAMPLE_TYPE);
                    newRow.Cells[SAMPLETYPE_COL].Value = st.PHRASE_DESCRIPTION;
                }

                if (shipmentUser.U_CLINIC != null)
                    newRow.Cells[clinicCol].Value = shipmentUser.U_CLINIC1.NAME;

            }
            const string sdg = "סה\"כ הפניות";
            const string samples = "סה\"כ צנצנות";
            //      lblOrders.Text = sdg + " : " + shipmentslist.Sum(x => x.U_CONTAINER_USER.U_NUMBER_OF_ORDERS).ToString();
            lblSamples.Text = samples + " : " +
                              shipmentslist.Sum(x => x.U_NUMBER_OF_SAMPLES).ToString();
        }

        private void BuildColumns(RadGridView dgShipments)
        {
            dgShipments.GridBehavior = new MyBehavior();
            dgShipments.AutoGenerateColumns = false;

            // System.Diagnostics.Debugger.Launch();
            var autoIncrement = new GridViewTextBoxColumn();
            autoIncrement.Name = "AutoIncrement";
            autoIncrement.HeaderText = "";
            autoIncrement.AllowResize = false;
            autoIncrement.ReadOnly = true;
            autoIncrement.IsPinned = true;
            // autoIncrement.Width = 44;
            dgShipments.Columns.Add(autoIncrement);


            var id = new GridViewTextBoxColumn();
            id.Name = "ID";
            id.HeaderText = "id";
            id.IsVisible = false;
            id.AllowResize = false;

            id.ReadOnly = true;
            id.IsPinned = true;
            //   id.Width = 44;
            dgShipments.Columns.Add(id);




            var clinics = new GridViewComboBoxColumn();
            clinics.Name = clinicCol;
            clinics.HeaderText = "גורם שולח";
            clinics.DisplayMember = "NAME";
            clinics.Width = 100;

            //   clinics.ValueMember = "U_CLINIC_ID";
            //    clinics.FieldName = "U_CONTAINER_USER.U_CLINIC";
            clinics.AutoCompleteMode = AutoCompleteMode.Suggest;
            clinics.DataSource = Clinics;
            clinics.AllowHide = false;

            dgShipments.Columns.Add(clinics);


            var sampletype = new GridViewComboBoxColumn();
            sampletype.Name = SAMPLETYPE_COL;
            sampletype.HeaderText = "סוג דגימה";
            sampletype.DisplayMember = "PHRASE_DESCRIPTION";
            sampletype.Width = 100;
            sampletype.ValueMember = "PHRASE_NAME";


            sampletype.AutoCompleteMode = AutoCompleteMode.Suggest;
            sampletype.DataSource = SampleTypes;
            sampletype.AllowHide = false;
            dgShipments.Columns.Add(sampletype);



            var Receive_Number = new GridViewTextBoxColumn();
            Receive_Number.Name = "Receive_Number";
            Receive_Number.HeaderText = "מספר ת.המשלוח ";
            //   Receive_Number.FieldName = "U_CONTAINER_USER.U_RECEIVE_NUMBER";
            dgShipments.Columns.Add(Receive_Number);






            var Send_On = new GridViewDateTimeColumn();
            Send_On.Name = "Send_On";
            Send_On.HeaderText = "נשלח בתאריך";
            Send_On.FormatString = "{0:dd/MM/yyyy}";
            //   Send_On.FieldName = "U_CONTAINER_USER.U_SEND_ON";


            dgShipments.Columns.Add(Send_On);





            //var sdgs = new GridViewDecimalColumn();
            //sdgs.Minimum = 0;
            //sdgs.Maximum = 9999999999;
            //sdgs.Name = SDG_COL;
            //sdgs.Width = 45;
            //sdgs.TextAlignment = ContentAlignment.MiddleCenter;
            //sdgs.DecimalPlaces = 0;
            //sdgs.HeaderText = "כמות הפניות";
            ////    sdgs.FieldName = "U_CONTAINER_USER.U_NUMBER_OF_ORDERS";
            //dgShipments.Columns.Add(sdgs);


            var samples = new GridViewDecimalColumn();
            samples.Minimum = 0;
            samples.Maximum = 9999999999;
            samples.Name = SAMPLES_COL;
            samples.Width = 45;
            samples.TextAlignment = ContentAlignment.MiddleCenter;
            samples.HeaderText = "כמות צנצנות";
            samples.DecimalPlaces = 0;

            dgShipments.Columns.Add(samples);

            var comments = new GridViewTextBoxColumn();
            comments.Name = "Comments";
            comments.HeaderText = "הערות";
            //   comments.Width = 200;
            dgShipments.Columns.Add(comments);

            //var shipmentName = new GridViewTextBoxColumn();
            //shipmentName.Name = "ShipmentName";
            //shipmentName.HeaderText = "מספר קבלה";
            //shipmentName.ReadOnly = true;
            ////   Receive_Number.FieldName = "U_CONTAINER_USER.U_RECEIVE_NUMBER";
            //dgShipments.Columns.Add(shipmentName);





            var bigCol = new GridViewDecimalColumn();
            bigCol.Minimum = 0;
            bigCol.Maximum = 9999999999;
            bigCol.Name = BIG_COL;
            bigCol.Width = 45;
            bigCol.TextAlignment = ContentAlignment.MiddleCenter;
            bigCol.HeaderText = "כמות גדולים";
            bigCol.DecimalPlaces = 0;
            dgShipments.Columns.Add(bigCol);


            var urgentCol = new GridViewDecimalColumn();
            urgentCol.Minimum = 0;
            urgentCol.Maximum = 9999999999;
            urgentCol.Name = URGENT_COL;
            urgentCol.Width = 45;
            urgentCol.TextAlignment = ContentAlignment.MiddleCenter;
            urgentCol.HeaderText = "כמות דחופים";
            urgentCol.DecimalPlaces = 0;
            dgShipments.Columns.Add(urgentCol);


            var print = new GridViewCommandColumn();
            print.Name = "print";
            print.UseDefaultText = true;
            print.DefaultText = "הדפס";
            print.HeaderText = "הדפס";
            //   print.Width = 55;
            print.ReadOnly = true;
            dgShipments.Columns.Add(print);



        }

        #endregion


        #region Private methods

        private void SaveRow(GridViewRowInfo row)
        {
            // // Debugger.Launch();

            var id = row.Cells["ID"].Value;


            if (id == null)
            {

                AddShipment(row);
            }
            else
            {
                UpdateShipment(row, id.ToString());
            }
        }

        private void AddShipment(GridViewRowInfo row)
        {
            var desc = (string)(row.Cells["Comments"].Value ?? null);

            var Send_On = row.Cells["Send_On"].Value;

            //   var U_NUMBER_OF_ORDERS = row.Cells[SDG_COL].Value;

            var U_NUMBER_OF_SAMPLES = row.Cells[SAMPLES_COL].Value;
            var U_BIG_QNT = row.Cells[BIG_COL].Value;
            var U_URGENT_QNT = row.Cells[URGENT_COL].Value;
            var smpt = row.Cells[SAMPLETYPE_COL].Value;
            var clinic = GetSelectedObject(row);

            var rn = row.Cells["Receive_Number"].Value;

            LoginXmlHandler login = new LoginXmlHandler(sp, "Add_Container");
            login.CreateLoginXml("U_CONTAINER", "Shipment");
            if (Send_On != null) login.AddProperties("U_SEND_ON", Send_On.ToString());




            if (smpt != null) login.AddProperties("U_SAMPLE_TYPE", smpt.ToString());


            //if (U_NUMBER_OF_ORDERS != null) 
            //  login.AddProperties("U_NUMBER_OF_ORDERS", U_NUMBER_OF_ORDERS.ToString());

            if (U_NUMBER_OF_SAMPLES != null)
                login.AddProperties("U_NUMBER_OF_SAMPLES", U_NUMBER_OF_SAMPLES.ToString());

            if (U_BIG_QNT != null)
                login.AddProperties("U_BIG_QNT", U_BIG_QNT.ToString());

            if (U_URGENT_QNT != null)
                login.AddProperties("U_URGENT_QNT", U_URGENT_QNT.ToString());

            if (clinic != null) login.AddProperties("U_CLINIC", clinic.NAME);
            if (rn != null) login.AddProperties("U_RECEIVE_NUMBER", rn.ToString());
            if (desc != null) login.AddProperties("DESCRIPTION", desc);








            var s = login.ProcssXml();
            if (!s)
            {
                MessageBox.Show("Error" + login.ErrorResponse, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else //Print label where container is added
            {
                var cid = login.GetValueByTagName("U_CONTAINER_ID");
                PrintLabel(cid);
            }
        }


        private void UpdateShipment(GridViewRowInfo row, string objId)
        {
            long id;
            var b = long.TryParse(objId, out id);
            if (!b)
            {
                MessageBox.Show("Error", mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Logger.WriteQueries("Error on update shipment");
                return;
            }
            var receiveShipmentUser = shipmentslist.SingleOrDefault(x => x.U_CONTAINER_ID == id);

            if (receiveShipmentUser != null)
            {
                var receiveShipment = receiveShipmentUser.U_CONTAINER;

                receiveShipmentUser.U_RECEIVE_NUMBER = (string)(row.Cells["Receive_Number"].Value ?? null);

                receiveShipmentUser.U_SEND_ON = (DateTime?)row.Cells["Send_On"].Value;

                //receiveShipmentUser.U_NUMBER_OF_ORDERS = row.Cells[SDG_COL].Value as decimal?;

                receiveShipmentUser.U_NUMBER_OF_SAMPLES = row.Cells[SAMPLES_COL].Value as decimal?;

                receiveShipmentUser.U_CLINIC1 = GetSelectedObject(row);


                receiveShipmentUser.U_SAMPLE_TYPE = (string)(row.Cells[SAMPLETYPE_COL].Value ?? null);



                receiveShipmentUser.U_BIG_QNT = row.Cells[BIG_COL].Value as decimal?;

                receiveShipmentUser.U_URGENT_QNT = row.Cells[URGENT_COL].Value as decimal?;


                //Ashi 1/8/21 Change To Received Status
                if (receiveShipmentUser.U_STATUS == "U")
                {
                    receiveShipmentUser.U_STATUS = "V";
                    receiveShipmentUser.U_RECEIVED_ON = DateTime.Now;

                    try
                    {
                        INautilusUser _ntlsUser = Utils.GetNautilusUser(sp);
                        if (_ntlsUser != null)
                        {
                            receiveShipmentUser.U_CREATE_BY = Convert.ToInt64(_ntlsUser.GetOperatorId());
                        }
                    }
                    catch (Exception ex)
                    {
                        receiveShipmentUser.U_CREATE_BY = null;
                    }

                }

            }
            dal.SaveChanges();

            PrintLabel(id.ToString());
        }
        private PHRASE_ENTRY GetSampleType(GridViewRowInfo row)
        {
            if (row.Cells[SAMPLETYPE_COL] == null) return null;
            var value = row.Cells[SAMPLETYPE_COL].Value;
            if (value != null)
            {
                var smptype = value.ToString();
                PHRASE_ENTRY p = SampleTypes.FirstOrDefault(x => x.PHRASE_DESCRIPTION == smptype);
                if (p != null)
                    return p;
            }
            return null;
        }

        private U_CLINIC GetSelectedObject(GridViewRowInfo row)
        {
            if (row.Cells[clinicCol] == null) return null;
            var value = row.Cells[clinicCol].Value;
            if (value != null)
            {
                var clinicName = value.ToString();
                U_CLINIC p = Clinics.FirstOrDefault(x => x.NAME == clinicName);
                return p;
            }
            return null;
        }

        //private U_CLINIC GetSelectedObject(GridViewRowInfo row)
        //{
        //    if (row.Cells[clinicCol] == null) return null;
        //    var value = row.Cells[clinicCol].Value;
        //    if (value != null)
        //    {
        //        var clinicName = value.ToString();
        //        U_CLINIC p = Clinics.FirstOrDefault(x => x.NAME == clinicName);
        //        return p;
        //    }
        //    return null;
        //}

        private void PrintLabel(string cid)
        {
            FireEventXmlHandler printEvent = new FireEventXmlHandler(sp, "Print_container");
            printEvent.CreateFireEventXml("U_CONTAINER", long.Parse(cid), "Print Label");
            var printSuccess = printEvent.ProcssXml();
            if (!printSuccess)
            {
                MessageBox.Show("Error in print label" + printEvent.ErrorResponse, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private bool ValidateOrdSamp(GridViewRowInfo row)
        //{
        //    int sdgCount = 0;
        //    int smpCount = 0;

        //    var sdgVal = row.Cells[SDG_COL].Value;
        //    var smpVal = row.Cells[SAMPLES_COL].Value;
        //    if (sdgVal == null || smpVal == null)
        //    {
        //        return false;
        //    }

        //    var b = int.TryParse(sdgVal.ToString(), out sdgCount);
        //    if (b)
        //        b = int.TryParse(smpVal.ToString(), out smpCount);

        //    if (!b || sdgCount > smpCount)
        //        return false;

        //    return true;
        //}


        private bool CanSave()
        {
            bool isValid = true;

            foreach (GridViewRowInfo row in gridShipments.Rows)
            {

                int rowIndex = row.Index + 1;

                var clinic = GetSelectedObject(row);
                if (clinic == null)
                {
                    string s = string.Format("לא נבחרה מרפאה בשורה {0}.", (rowIndex));
                    MessageBox.Show(s, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    isValid = false;
                    break;
                }

                if (row.Cells[SAMPLETYPE_COL] == null)
                {

                    isValid = noSampleTypeError(rowIndex);
                    break;
                }
                else if (row.Cells[SAMPLETYPE_COL].Value == null)
                {
                    isValid = noSampleTypeError(rowIndex);
                    break;
                }

                //var value = row.Cells[clinicCol].Value;

                //if (!ValidateOrdSamp(row))
                //{
                //    string s = string.Format(errMsg + " בשורה " + (row.Index + 1));

                //    MessageBox.Show(s, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error,
                //                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                //    return false;
                //}
                //if ( BigUrgValidate ( row ) )
                //{
                //    string s = string.Format ( bigUrg_errMsg + " בשורה " + ( row.Index + 1 ) );

                //    MessageBox.Show(s, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error,
                //        MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                //    return false;
                //}




            }
            return isValid;
        }

        private bool noSampleTypeError(int rowIndex)
        {
            string s = string.Format("לא נבחרה סוג דגימה בשורה {0}.", (rowIndex));
            MessageBox.Show(s, mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            return false;
        }



        #endregion


        #region button events

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  Debugger.Launch();

            if (CanSave())
            {


                foreach (GridViewRowInfo row in gridShipments.Rows)
                {
                    SaveRow(row);
                }

                InitilaizeGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var dg = MessageBox.Show("האם אתה בטוח שברצונך לצאת?", mboxHeader, MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                     MessageBoxOptions.RtlReading);
            if (dg == DialogResult.Yes)


                if (_ntlsSite != null) _ntlsSite.CloseWindow();
        }

        #endregion


        #region Grid events

        private void gridShipments_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
            if (gridShipments.CurrentRow.Cells["id"].Value == null)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("לא ניתן למחוק רשומה קיימת.", mboxHeader, MessageBoxButtons.OK, MessageBoxIcon.Hand,
                                MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void gridShipments_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {

            RadDropDownListEditor dropDownEditor = this.gridShipments.ActiveEditor as RadDropDownListEditor;
            if (dropDownEditor != null)
            {
                RadDropDownListEditorElement dropDownEditorElement =
                    (RadDropDownListEditorElement)dropDownEditor.EditorElement;

                dropDownEditorElement.AutoCompleteMode = AutoCompleteMode.Suggest;
                dropDownEditorElement.AutoCompleteSuggest = new CustomAutoSuggestHelper(dropDownEditorElement);
                dropDownEditorElement.DropDownStyle = RadDropDownStyle.DropDown;
                dropDownEditorElement.Font = gridShipments.Font; // a font
                dropDownEditorElement.ListElement.Font = gridShipments.Font; // a font
            }
        }

        private void gridShipments_CommandCellClick(object sender, EventArgs e)
        {
            try
            {

                var gCommand = (sender as GridCommandCellElement);
                if (gCommand == null) return;


                var colValue = gCommand.RowInfo.Cells["ID"];

                if (colValue.Value != null)
                {
                    PrintLabel(colValue.Value.ToString());

                }
                else
                {
                    MessageBox.Show("לא ניתן להדפיס מדבקה לציידנית שטרם נשמרה. ", mboxHeader, MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand,
                                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {

                Logger.WriteLogFile(ex);
            }

        }

        private void gridShipments_UserAddedRow(object sender, GridViewRowEventArgs e)
        {

            var count = gridShipments.Rows.Count;
            e.Row.Cells["autoIncrement"].Value = count;
            //   e.Row.Cells[clinicCol].BeginEdit();
        }

        private void gridShipments_DefaultValuesNeeded_1(object sender, GridViewRowEventArgs e)
        {
            if (this.gridShipments.CurrentRow is GridViewNewRowInfo)
            {
                e.Row.Cells["SEND_ON"].Value = DateTime.Now;
            }

        }

        private void ReciveShipmentCls_Resize(object sender, EventArgs e)
        {
            lblHeader.Location = new Point(Width / 2 - lblHeader.Width / 2, lblHeader.Location.Y);
        }

        private void gridShipments_CellFormatting(object sender, CellFormattingEventArgs e)
        {

            switch (e.CellElement.ColumnInfo.Name)
            {
                case clinicCol:
                    setMandatoryCellColor(e, clinicCol);
                    break;

                case SAMPLETYPE_COL:
                    setMandatoryCellColor(e, SAMPLETYPE_COL);
                    break;
                default:
                    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
                    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                    break;
            }

            //if (e.CellElement.ColumnInfo.Name == clinicCol)
            //{
            //    var ClinicCol = e.Row.Cells[clinicCol];
            //    if (ClinicCol.Value == null)//not valid
            //    {
            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Crimson;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;
            //    }
            //    else
            //    {
            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Black;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;
            //    }
            //}

            ////-------------------------------------------------------------------------------------------//
            //if (e.CellElement.ColumnInfo.Name == SAMPLETYPE_COL)
            //{
            //    var sampleTypeCol = e.Row.Cells[SAMPLETYPE_COL];
            //    if (sampleTypeCol.Value == null)//not valid
            //    {
            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Crimson;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;
            //    }
            //    else
            //    {
            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Black;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;
            //    }
            //}
            ////-------------------------------------------------------------------------------------------//






            //else if (e.CellElement.ColumnInfo.Name == SAMPLES_COL || e.CellElement.ColumnInfo.Name == SDG_COL)
            //{

            //    if (ValidateOrdSamp(e.Row))
            //    {
            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Black;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;



            //    }
            //    else //not valid
            //    {


            //        e.CellElement.DrawFill = true;
            //        e.CellElement.ForeColor = Color.Crimson;
            //        e.CellElement.NumberOfColors = 1;
            //        e.CellElement.BackColor = Color.AntiqueWhite;



            //    }
            //}
            //else
            //{
            //    e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            //    e.CellElement.ResetValue(LightVisualElement.ForeColorProperty, ValueResetFlags.Local);
            //    e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
            //    e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            //}

        }

        private static void setMandatoryCellColor(CellFormattingEventArgs e, string cellHeader)
        {
            var cell = e.Row.Cells[cellHeader];
            if (cell.Value == null)//not valid
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.Crimson;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.AntiqueWhite;
            }
            else
            {
                e.CellElement.DrawFill = true;
                e.CellElement.ForeColor = Color.Black;
                e.CellElement.NumberOfColors = 1;
                e.CellElement.BackColor = Color.AntiqueWhite;
            }
        }

        private void gridShipments_CreateRowInfo(object sender, GridViewCreateRowInfoEventArgs e)
        {

        }

        private void gridShipments_CreateRow(object sender, GridViewCreateRowEventArgs e)
        {

        }

        #endregion



        private void radButton1_Click(object sender, EventArgs e)
        {
            gridShipments.EndEdit();
            var r = gridShipments.Rows.AddNew();
            r.Cells[clinicCol].BeginEdit();
        }

        private void txtAssutaReq_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtAssutaReq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                shipmentslist = dal.FindBy<U_CONTAINER_USER>(x => x.U_RECEIVE_NUMBER == txtAssutaReq.Text.Trim()).ToList();
                if (shipmentslist != null && shipmentslist.Count > 0)
                {
                    gridShipments.Rows.Clear();
                    PopulateData(shipmentslist);
                }
                else
                {
                    string msg = ("מס משלוח לא קיים במערכת.");
                    var dg = MessageBox.Show(msg, mboxHeader, MessageBoxButtons.OK,
                                  MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                  MessageBoxOptions.RtlReading);
                    txtAssutaReq.Text = "";
                    txtAssutaReq.Focus();
                }

            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtAssutaReq.Text = string.Empty;
            gridShipments.Rows.Clear();
            txtAssutaReq.Focus();
        }

        private void txtAssutaReq_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class CustomAutoSuggestHelper : AutoCompleteSuggestHelper
    {
        public CustomAutoSuggestHelper(RadDropDownListElement owner)
            : base(owner)
        {
        }

        protected override bool DefaultFilter(RadListDataItem item)
        {
            return item.Text.Contains(this.Filter);
        }
    }
    public class MyBehavior : BaseGridBehavior
    {
        public override bool ProcessKeyDown(KeyEventArgs keys)
        {
            if (keys.KeyData == Keys.Enter && this.GridControl.IsInEditMode)
            {
                this.GridControl.GridNavigator.SelectNextColumn();
            }
            return true;
        }
    }

}



