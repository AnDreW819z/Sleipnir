import { Injectable } from '@angular/core';
import { CardGenre } from '../interfaces/card-genre';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class GenreItemService {

  constructor(
    private httpClient: HttpClient,
  ) { }

  public pageItems: CardGenre[] = [
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    {
      id: 1,
      name: "рок",
      imageUrl: "https://sneg.top/uploads/posts/2023-03/1678603701_sneg-top-p-oboi-dlya-aifona-rok-vkontakte-68.jpg"
    },
    
    
  ];

  public getGenreItems(): CardGenre[] {
    return this.pageItems;
  }

  public getAllGenres(): Observable<CardGenre[]> {
    return this.httpClient.get<CardGenre[]>(environment.apiUrl + 'Genre/getGenres')
  }
}
