# MadCampWeek3 : KTD (KAIST Tower Defense)
Unity Tower Defense Game Project

[Click to Play](https://jinhyeonkwon.github.io/KTD_Deploy) (Screen Size : 1920 * 1080)

## Our Team

|Teammates|University|github|
|------|---|---|
|Dongwoo Jang|Hanyang University|[jjangddu](http://github.com/jjangddu)|
|Jinhyeon Kwon|KAIST|[jinhyeonkwon](http://github.com/jinhyeonkwon)|
|Mingyu Kim|KAIST|[mingyu0304](http://github.com/mingyu0304)|
<br/>

## 📚STACKS
<div align=left> 
<img src="https://img.shields.io/badge/java-007396?style=for-the-badge&logo=java&logoColor=white"> 
<img src="https://img.shields.io/badge/python-3776AB?style=for-the-badge&logo=python&logoColor=white"> 
<img src="https://img.shields.io/badge/javascript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black">
<img src="https://img.shields.io/badge/react-61DAFB?style=for-the-badge&logo=react&logoColor=black"> 
<img src="https://img.shields.io/badge/django-092E20?style=for-the-badge&logo=django&logoColor=white">
<br/>

## Game Screenshots
<br/>
사진넣기<br/>
Login page
<br/>
<br/>
사진넣기<br/>
Singup Page
<br/>
<br/>
사진넣기<br/>
Profile Page
<br/>
<br/>
사진넣기<br/>
Game Page
<br/>


## Game Info

We used django channels to make websocket backend. <br/>
In game page, we have chatting and drawing componenets. We used 'usewebsocket' library for chatting, and 'w3cwebsocket' library for drawing componenets. It was easy to make chatting page synchronize with websocket backend, but drawing page was hard to synchronize. So we find new method to show our server's canvas in game page, simply bringing canvas page into our react page.
<br/>

## How to play
You can put turrets by clicking 'basic turret(100)', "ice tower(200)', 'nupjuk turret(300)', 'fast turret(200)', 'strong turret(300)' and clicking black squares.
