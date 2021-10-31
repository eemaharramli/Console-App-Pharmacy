using System.Collections.Generic;
using System.Dynamic;
using Pharmacy.Models;

namespace Pharmacy.Utils
{
    
    public class LanguageDictionary
    {
        public Language Language { get; set; }
        private Dictionary<string, string> Texts;

        public LanguageDictionary(Language language)
        {
            this.Language = language;
            LoadTexts();
        }

        private void LoadTexts()
        {
            switch(Language)
            {
                case Models.Language.Eng: Texts = En(); break;
                case Models.Language.Rus: Texts = Ru(); break;
                case Models.Language.Aze: Texts = Az(); break;
            }
        }

        private Dictionary<string, string> En()
        {
            return new Dictionary<string, string>
            {
                {"inputUsrNm","Input your username"},
                {"inputPswd","Input your password"},
                {"checkCredentials", "Please wait while we check your credentials"},
                {"welcomeAd","Welcome administrator"},
                {"welcomeUs","Welcome user"},
                {"menuTitle","Please choose one of the above \n"},
                {"add","1 - Add Drug \n"},
                {"show","2 - Show all Drugs \n"},
                {"searchDrug","3 - Search Drug \n"},
                {"buy","4 - Buy Drug \n"},
                {"showDrugsByCategory","5 - Show drugs by Category \n"},
                {"showCategories","6 - Show Categories of drugs \n"},
                {"logoff","7 - Sign out \n"},
                {"exit","8 - Exit \n"},
                {"bye", "Thanks for using our app"},
                {"errorAdd", "Only admin can add drug"},
                {"inputDrugName", "Input the Drug name"},
                {"emptyName", "Drug name can't be empty"},
                {"emptyType", "Drug type can't be empty"},
                {"inputDrugType", "Please input the Drug type"},
                {"inputDrugCount", "Please input the Drug count"},
                {"inputDrugCountIndex","Please input the count of {0} drug"},
                {"inputCategory", "Please input the category"},
                {"drugNameError", "Drug name can't be only a number, name can include number. Try again"},
                {"drugTypeError", "Drug type can't be a number. Try again"},
                {"drugCountError", "Drug Count must be a number. Try again"},
                {"drugCategoryError", "Sorry, but we haven't drugs in category {0}"},
                {"newDrugMsg","New drug added"},
                {"oldDrugMsg","Old drug change count"},
                {"emptyPharmacy","There is no drugs in pharmacy yet. Please add new drug"},
                {"showDrugs","Here is the all drugs in our pharmacy"},
                {"drugCostMsg", "The {0} will be cost {1} AZN. Please enter the purchase: "},
                {"QuantityError", "Sorry, we haven't {0} with input quantity"},
                {"successfulPurchase", "The purchase was successful"},
                {"warningDrug","We haven't this drugs"},
                {"wrongInput", "Wrong input. Choose from the menu numbers"}
            };
        }
        
        private Dictionary<string, string> Ru()
        {
            return new Dictionary<string, string>
            {
                {"inputUsrNm","Введите имя пользователя"},
                {"inputPswd","Введите пароль"},
                {"checkCredentials", "Проверка данных. Это займёт не много времени"},
                {"welcomeAd","Добро пожаловать Администратор"},
                {"welcomeUs","Добро пожаловать Пользователь"},
                {"menuTitle","Выберите один из пунктов меню \n"},
                {"add","1 - Добавить лекарство \n"},
                {"show","2 - Показать все лекарства \n"},
                {"searchDrug","3 - Найти лекарство \n"},
                {"buy","4 - Купить лекарство \n"},
                {"showDrugsByCategory","5 - Показать лекарства по типу \n"},
                {"showCategories","6 - Показать типы лекарств\n"},
                {"logoff","7 - Сменить пользователя \n"},
                {"exit","8 - Выход \n"},
                {"bye", "Благодарим за исполькование наших услуг"},
                {"errorAdd", "Только Администратор может добавлять лекарства"},
                {"inputDrugName", "Введите имя лекарства"},
                {"inputDrugType", "Введите категорию лекарства"},
                {"emptyName", "Имя лекарства не может быть пустой строкой"},
                {"emptyType", "Тип лекарства не может быть пустой строкой"},
                {"inputDrugCount", "Введите количество лекарства"},
                {"inputDrugCountIndex","Введите количество {0} лекарства"},
                {"inputCategory", "Категории лекарств: "},
                {"drugNameError", "Имя лекарства не может состоять только из цифп. Попробуйте ещё раз"},
                {"drugTypeError", "Категория лекарства не может быть цифрой. Попробуйте ещё раз"},
                {"drugCountError", "Количество лекарства должно быть цифрой. Попробуйте ешё раз"},
                {"drugCategoryError", "К сожаление в категории {0} нет лекарств"},
                {"newDrugMsg","Новое лекарство добавлено"},
                {"oldDrugMsg","Количество данного лекарство в базе изменено"},
                {"emptyPharmacy","На данный момент в аптеке нет лекарств. Ввойдите под пользователем Администратора и добавьте лекарства"},
                {"showDrugs","Все лекарства в нашей аптеке:"},
                {"drugCostMsg", "Оплата {0} лекарств равна {1} AZN. Пожалуйста введите оплату"},
                {"QuantityError", "К сожалению в нашей аптеке нет лекарств {0} в введённом количестве"},
                {"successfulPurchase", "Оплата проведена успешно"},
                {"warningDrug","В нашей аптеке нет данных лекарств"},
                {"wrongInput", "Неправильный ввод. Выберите из указанного в меню"}
            };
        }
        
        private Dictionary<string, string> Az()
        {
            return new Dictionary<string, string>
            {
                {"inputUsrNm","Istifadechi adini daxil edin"},
                {"inputPswd","Shifreni daxil edin"},
                {"checkCredentials", "Yoxlanilir. Yoxlanish bir neche muddet cheke biler"},
                {"welcomeAd","Xosh gelmisiniz administrator"},
                {"welcomeUs","Xosh gelmisiniz user"},
                {"menuTitle","Ashaghidaki sechimlerden birini edin \n"},
                {"add","1 - Derman elave et \n"},
                {"show","2 - Butun dermanlari goster \n"},
                {"searchDrug","3 - Derman axtar \n"},
                {"buy","4 - Derman al \n"},
                {"showDrugsByCategory","5 - Dermanlari novune uyghun goster \n"},
                {"showCategories","6 - Derman novlerini goster \n"},
                {"logoff","7 - Istifadechini deyish \n"},
                {"exit","8 - Chixish \n"},
                {"bye", "Tetbiqimizi istifade etdiyiniz uchun teshekkur edirik"},
                {"errorAdd", "Yalniz Administrator yeni derman elave ede biler"},
                {"inputDrugName", "Dermanin adini daxil edin"},
                {"inputDrugType", "Dermanin novunun daxil edin"},
                {"emptyName", "Derman adi bosh setr ola bimez"},
                {"emptyType", "Derman novu bosh setr ola bimez"},
                {"inputDrugCount", "Dermanin sayini daxil edin"},
                {"inputDrugCountIndex","{0} dermanin sayini daxil edin"},
                {"inputCategory", "Movcud dermanlarin novleri: "},
                {"drugNameError", "Derman adi yalniz reqamden ibaret ola bilmez. Bir daha cehd edin"},
                {"drugTypeError", "Derman novu reqem ola bilmez. Bir daha cehd edin"},
                {"drugCountError", "Derman sayi reqem olmalidi. Yeniden cehd edin"},
                {"drugCategoryError", "Teessuf ki, {0} novunde derman yoxdur"},
                {"newDrugMsg","Yeni derman elave edildi"},
                {"oldDrugMsg","Dermanin sayi deyishildi"},
                {"emptyPharmacy","Aptekde hal-hazirda derman yoxdur. Administrator adindan daxil olub derman elave edin"},
                {"showDrugs","Aptekimizde olan dermanlar: "},
                {"drugCostMsg", "{0} dermanin qeyd edilen sayda qiymeti {1} AZN beraberdi. Odemeni teqdim edin: "},
                {"QuantityError", "Teessuf ki qeyd edilen sayda {0} dermani aptekde movcud deyil"},
                {"successfulPurchase", "Odeme ughurla tamamlandi"},
                {"warningDrug","Aptekde qeyd edilen dermanlar movcud deyil"},
                {"wrongInput", "Yanlish. Zehmet olmasa bashliqlarda qeyd edilen reqemlerden daxil edin"}
            };
        }

        public string Get(string key)
        {
            return Texts[key];
        }
    }
}