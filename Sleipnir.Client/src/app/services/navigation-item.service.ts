import { Injectable } from '@angular/core';
import { NavList } from '../interfaces/nav-list';

@Injectable({
  providedIn: 'root'
})
export class NavigationItemService {

  constructor() { }

  public pageItems: NavList[] = [
    {
      name: "music",
      icon: "music_note",
      link: "popular"
    },
    {
      name: "musicians",
      icon: "groups",
      link: "musicians"
    },
    {
      name: "playlists",
      icon: "playlist_play",
      link: "playlists"
    }
  ];
  public rightPageItems: NavList[] = [
    {
      name: "Popular",
      icon: "",
      link: "popular"
    },
    {
      name: "By genre",
      icon: "",
      link: "genre"
    },
    {
      name: "By mood",
      icon: "",
      link: "mood"
    }
  ];
  
  public getpageItems(): NavList[] {
    return this.pageItems;
  }
  public getrightPageItems(): NavList[] {
    return this.rightPageItems;
  }
}
