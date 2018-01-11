const languageType = {
    pl: 'pl',
    en: 'en'
}

interface ITranslations {
    [key: string]: any;
    GetValue(key: string): any;
    GetValue(key: string, language: string): string;
}

export const Translations: ITranslations = {

    //NAV
    Nav_Header: { pl: 'Foodinio', en: 'Foodinio' },

    //NAV MENU ITEMS
    Menu_Home: { pl: 'Strona główna', en: 'Welcome' },
    Menu_Menu: { pl: 'Menu', en: 'Menu' },
    Menu_Reservations: { pl: 'Rezerwacja', en: 'Reservations' },
    Menu_News: { pl: 'Nowości', en: 'News' },
    Menu_Contact: { pl: 'Kontakt', en: 'Contact' },

    //BUTTONS
    Button_Sign_In: { pl: 'Zaloguj', en: 'Sign In' },
    Button_Sign_Up: { pl: 'Zarejestruj się!', en: 'Sign Up' },
    Button_Forgot_Password: { pl: 'Zapomniałeś hasła?', en: 'Have you forgotten your password?' },

    //INPUTS PLACEHOLDERS
    Input_Email: { pl: 'przykladowy@domena.com', en: 'example@domain.com' },
    Input_Password: { pl: 'Musi posiadać minimum 6 znaków', en: 'Must have at least 6 characters' },

    //LABELS
    Label_Email: { pl: 'Email', en: 'Email' },
    Label_Password: { pl: 'Hasło', en: 'Password' },

    //PARAGRAPHS
    Paragraph_Sign_Up: { pl: 'Nie posiadasz konta?', en: "Don't have an account?" },


    GetValue(key: string, language: string = languageType.pl): string {
        const translation = Translations[key];
        if (!translation) {
            // return `Translation: ${key} does not exist.`;
            return `${key}`;
        }
        return translation[language];
    }
}
