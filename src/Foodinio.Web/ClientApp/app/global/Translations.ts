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

    GetValue(key: string, language: string = languageType.pl): string {
        const translation = Translations[key];
        if (!translation) {
            return `Translation: ${key} does not exist.`;
        }
        return translation[language];
    }
}
