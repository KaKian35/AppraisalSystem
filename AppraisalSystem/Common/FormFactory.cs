using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppraisalSystem.Common
{
    public class FormFactory
    {
/*      private static FrmBaseManager frmBaseManager;
        private static FrmUserManager frmUserManager;
        private static FormNone formNone;*/

        private static Form form;
        private static List<Form> forms = new List<Form>();
        /*        public static Form CreateForm(int Index)
                {
                    HideFormAll();
                    switch (Index)
                    {
                        case 0:
                            if (frmUserManager == null)
                            {
                                frmUserManager = new FrmUserManager();
                            }
                            form = frmUserManager;
                            forms.Add(frmUserManager);
                            break;

                        case 1:
                            if (frmBaseManager == null)
                            {
                                frmBaseManager = new FrmBaseManager();
                            }
                            form = frmBaseManager;
                            forms.Add(frmBaseManager);
                            break;

                        default:
                            if (formNone == null)
                            {
                                formNone = new FormNone();
                            }
                            form = formNone;
                            forms.Add(formNone);
                            break;
                    }
                    return form;
                }*/

        private static List<Type> types;
        static FormFactory()
        {
            Assembly ass = Assembly.Load("AppraisalSystem");
            types = ass.GetTypes().ToList();

        }
        public static Form CreateForm(string FormName)
        {
/*          string path = AppDomain.CurrentDomain.BaseDirectory;*/
            /*Type[] types = ass.GetTypes().Where(m=>m.BaseType == typeof(Form)).ToArray();*/
            HideFormAll();
            FormName = FormName == null ? "FormNone":FormName;

            Form form = forms.Find(m=> m.Name == FormName);
            if (form == null)
            {
                Type type = types.Find(m => m.Name == FormName);
                form = (Form)Activator.CreateInstance(type);
                forms.Add(form);
            }

            return form;
        }
        public static void HideFormAll()
        {
/*          frmUserManager?.Hide();
            frmBaseManager?.Hide();*/

            foreach (var form in forms)
            {
                form.Hide();
            }
        }
    }
}
