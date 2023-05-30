# Dance School Internal System [Bachelor's Thesis]

# Description
This project serves as a showcase of the current state of my bachelor's thesis. This system will be used in practice by an unnamed Dance School in Brno. The goal of this system is to allow management of users, lessons, training halls, communication between users etc. Each user can have up to 3 roles at the same time - manager, trainer, student. Each student is part of a pair, by which he/she signs up for a lesson. Apart from this, we have dance types - STT/LAT, which are reflected in lessons respectively. Other than that, each user has a dance level, which he/she teaches/studies. Lessons can be recurring, or one time. We also have group lessons, and individual lessons. Teachers will be able to create their "free blocks" in which they are free to teach a lesson. They can either sign up a specific pair, or the pair can sign up for the lesson if they wish to. The system must be able to reflect all these changes. 

# Timeline
[**.12.2022] - I signed up for this bachelor's thesis, had a meeting with the supervisor and was told the rough idea of requirements for this project.

[1.1.2023] - [30.4.2023] - There was no time for development or meetings thanks to my packed semester and working position. 

[10.5.2023] - Meeting with my supervisor. I was given more information, restrictions, requirements...

Development started.

[30.5.2023] - Day of publishing the state of this project to gihub/gitlab.

# Project status

As of this day [30.5.2023], not much is done in terms of frontend. My main focus right now is on the backend part of this project. As I care about the quality of my code, I decided to structure my code responsibly. I'm taking advantage of Services, Repositories, DTOs, UOW... So far the biggest problem was authorization and role management, as users can have more than one role and I'd like to authorize them according to their roles. I could have scaffolded Identity, but I'd like to keep away from razor pages in the long run, and also I wanted to implement the authorization myself.

This is WIP, very rough skeleton of what the final product will be. Please keep this in mind when looking at the code.

# Contact

In case of any questions, suggestions, or conversation in general, feel free to contact me at `pavol.cajkovsky@gmail.com`
