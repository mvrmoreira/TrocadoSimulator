using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrocadoSimulator.BusinessLogic;
using TrocadoSimulator.BusinessLogic.DataContracts;

namespace TrocadoSimulator {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }



        private void UxBtnSubmit_Click(object sender, EventArgs e) {
            this.UxTxtChangeAmount.Text = this.CalculateChange(this.UxTxtPaidAmount.Text, this.UxTxtProductAmount.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paidAmount"></param>
        /// <param name="productAmount"></param>
        /// <returns></returns>
        private string CalculateChange(string paidAmount, string productAmount){

            // Limpa mensagem de erro
            this.UxTxtOutput.Text = string.Empty;

            // Monta o request
            ChangeRequest changeRequest = new ChangeRequest();
            changeRequest.PaidAmount = int.Parse(paidAmount);
            changeRequest.ProductAmount = int.Parse(productAmount);

            // Chama o calculo do troco
            ChangeManager changeManager = new ChangeManager();

            // Assina o evento de conclusão de processador.
            changeManager.OnProcessorDone += changeManager_OnProcessorDone;

            ChangeResponse changeResponse = changeManager.CalculateChange(changeRequest);

            // Verifica se o calculo foi feito corretamente
            if (changeResponse.Success == true) {

                // Instancia montador de string
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendFormat("Moedas:");

                foreach (ChangeData changeInCoin in changeResponse.ChangeDataCollection) {
                    stringBuilder.AppendFormat("\r\n{0} {1}(s) de {2} centavo(s)", changeInCoin.Quantity, changeInCoin.Name, changeInCoin.AmountInCents);
                }

                // Devolve a mensagem de erro para a interface
                this.UxTxtOutput.AppendText(stringBuilder.ToString());

                // Retorna troco
                return changeResponse.ChangeAmount.ToString();
            }
            else {

                // Instancia montador de string
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendFormat("Deu ruim!");

                // Varre a coleção de erros
                foreach (ErrorReport errorReport in changeResponse.ErrorReport) {
                    stringBuilder.AppendFormat("\r\nErro no campo {0}: {1}", errorReport.Field, errorReport.Message);
                }

                // Devolve a mensagem de erro para a interface
                this.UxTxtOutput.AppendText(stringBuilder.ToString());

                // Retorna troco vazio
                return string.Empty;
            }
        }

        void changeManager_OnProcessorDone(object sender, ProcessorDoneEventArgs e)
        {
            this.UxTxtOutput.AppendText(string.Format("{0}: {1}\r\n", e.Name, e.ChangeAmountInCents));
        }
    }
}
