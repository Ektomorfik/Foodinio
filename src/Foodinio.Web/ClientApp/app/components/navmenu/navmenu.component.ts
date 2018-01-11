import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {

    @ViewChild('hamburger') menuButton: ElementRef;
    constructor() {

    }
    toggleMenu() {
        this.menuButton.nativeElement.classList.toggle('visible');
    }
}
