import { Component, OnInit } from '@angular/core';

import { MatToolbarModule } from '@angular/material/toolbar'
import { MatIconModule } from '@angular/material/icon'
import { MatTableModule } from '@angular/material/table'
import { MatButtonModule } from '@angular/material/button'
import { MatSliderModule } from '@angular/material/slider'

import { Music } from '../../interfaces/music';
import { CommonModule } from '@angular/common';
import * as moment from 'moment';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-player',
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatSliderModule,
    FormsModule
  ],
  templateUrl: './player.component.html',
  styleUrl: './player.component.scss'
})
export class PlayerComponent implements OnInit {

  //audio: HTMLAudioElement;
  constructor() {
    this.audio.volume = this.volume;

    this.audio.ondurationchange = () => {
      const totalSeconds = Math.floor(this.audio.duration),
        duration = moment.duration(totalSeconds, 'seconds');
      this.musicLength = duration.seconds() < 10 ?
        `${Math.floor(duration.asMinutes())}:
                0${duration.seconds()}` :
        `${Math.floor(duration.asMinutes())}:
                ${duration.seconds()}`;
      this.duration = totalSeconds;
    }

    this.audio.ontimeupdate = () => {
      const duration = moment.duration(
        Math.floor(this.audio.currentTime), 'seconds');
      this.currentTime = duration.seconds() < 10 ?
        `${Math.floor(duration.asMinutes())}:
                0${duration.seconds()}` :
        `${Math.floor(duration.asMinutes())}:
                ${duration.seconds()}`;
    }

    // this.getAllMusic().subscribe((musicList: Music[]) => {
    //   this.musicList = musicList;
    // });

    
  }

  selectedValue = 100;
  selectedTime = 0;

  volume: number = 1;
  saveVolume: number = 0;
  audio = new Audio();
  musicLength: string = '0:00';
  duration: number = 1;
  currentTime: string = '0:00';

  public musicList: Music[] = [
    {
      album: "album1",
      title: "Jungle",
      artist: "Alok",
      url: "https://slipknotation.narod.ru/mp3/slipknot/Slipknot_-_Wait_and_bleed.mp3"
    },
    {
      album: "album2",
      title: "In My Room (VIP Mix)",
      artist: "Dombresky & Makinn feat SHELLS",
      url: "./././assets/audio/Dombresky_&_Makinn_-_In_My_Room_ft._SHELLS_(VIP).mp3"
    },
    {
      album: "album3",
      title: "Still Fal",
      artist: "Felix Jaehn",
      url: "./././assets/audio/Felix_Jaehn_-_Still_Fal.mp3"
    },
  ];
  displayedColumns: string[] = ['title', 'artist', 'album'];
  trackPointer: number = 0;
  currentMusic: Music = {
    album: "",
    title: "",
    artist: "",
    url: ""
  }

  ngOnInit(): void {
    //this.selectedTime = this.audio.currentTime;
    // this.audio.ontimeupdate = () => {
    //   this.selectedTime = this.audio.currentTime;
    // };

    this.audio.ondurationchange = () => {
      const totalSeconds = Math.floor(this.audio.duration),
        duration = moment.duration(totalSeconds, 'seconds');
      this.musicLength = duration.seconds() < 10 ?
        `${Math.floor(duration.asMinutes())}:
                0${duration.seconds()}` :
        `${Math.floor(duration.asMinutes())}:
                ${duration.seconds()}`;
      this.duration = totalSeconds;
    }

    this.audio.ontimeupdate = () => {
      this.selectedTime = this.audio.currentTime;
      const duration = moment.duration(
        Math.floor(this.audio.currentTime), 'seconds');
      this.currentTime = duration.seconds() < 10 ?
        `${Math.floor(duration.asMinutes())}:
                0${duration.seconds()}` :
        `${Math.floor(duration.asMinutes())}:
                ${duration.seconds()}`;
    }
  }

  play(index?: number): void {
    if (index === undefined) {
      if (this.audio.paused) {
        if (this.audio.readyState === 0) {
          this.trackPointer = 0;
          this.currentMusic = this.musicList[0];
          this.audio.src = this.currentMusic.url;
        }
        this.audio.play();
      } else {
        this.audio.pause();
      }
    } else {
      this.trackPointer = index;
      this.currentMusic = this.musicList[index];
      this.audio.src = this.currentMusic.url;
      this.audio.play();
    }
  }

  prev(): void {
    if (this.trackPointer > 0) {
      this.trackPointer--;
      this.currentMusic = this.musicList[this.trackPointer];
      this.audio.src = this.currentMusic.url;
      this.audio.play();
    }
  }

  next(): void {
    if (this.trackPointer < this.musicList.length - 1) {
      this.trackPointer++;
      this.currentMusic = this.musicList[this.trackPointer];
      this.audio.src = this.currentMusic.url;
      this.audio.play();
    }
  }

  volumeSlider(event: any) {
    let volume = this.selectedValue;
    this.audio.volume = this.selectedValue / 100;
  }

  durationSlider(event: any) { 
    //this.selectedTime = this.audio.readyState === 0 ? 0 : this.audio.currentTime;
    this.audio.currentTime = this.selectedTime;
    //this.selectedTime = event.value;
  }

  volume_on(): void {
    if (this.selectedValue !== 0) {
      this.saveVolume = this.selectedValue;
      this.selectedValue = 0;
    }
    else {
      this.selectedValue = this.saveVolume;
    }
  }

  playSong(): void {
    if (this.audio.paused) {
      this.audio.src = './././assets/music.mp3';
      this.audio.load();
      this.audio.play();
    }
    else {
      this.audio.pause();
    }
  }


}