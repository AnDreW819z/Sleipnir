import { Component, OnInit } from '@angular/core';
import { NavList } from '../../interfaces/nav-list';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterModule } from '@angular/router';
import { NavigationItemService } from '../../services/navigation-item.service';
import { MusiciansItemService } from '../../services/musicians-item.service';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterModule],
  templateUrl: './navigation.component.html',
  styleUrl: './navigation.component.scss'
})
export class NavigationComponent implements OnInit{

  constructor(
    public navigationService: NavigationItemService,
    public musicianItem: MusiciansItemService,
    private authService: AuthService,
    private router: Router,
    ) { }

  public navItems: NavList[] = [];
  public rightNavItems: NavList[] = [];
  public activatedItemName: string = 'music';
  public activatedRightItemName: string = 'Popular';

  public ngOnInit(): void {
    this.navItems = this.navigationService.getpageItems();
    this.rightNavItems = this.navigationService.getrightPageItems();
  }

  public onItemClick(item: NavList): void {
   this.activatedItemName = item.name;
    this.authService.closeUser();
  }

  public onRightItemClick(item: NavList): void {
    this.activatedRightItemName = item.name;
    this.authService.closeUser();
  }
}

