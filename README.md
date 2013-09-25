Theremin-tutor-application-for-windows-phone-8
==============================================

At the moment, I know that there is no tool available to help with learning theTheremin. From information above we know that there is very little hand-eye reference to gauge the pitch that you will play, but I think a windows phone application could be designed to solve this. The user can place the phone on the Theremin itself so it does not interfere with the antennas. That's why we decide to design a windows phone application to solve this. The application requires a GUI for the user and an audio processing engine. The audio processing engine will listen to the audio from the Theremin and use the Fourier transform to determine its true frequency. This will be displayed to the user on a gauge on the GUI which shows different frequencies between 0-2000Hz. The gauge has a pointer arrow.. When we get the current frequency by using Fourier transform, this arrow should point to the correct frequency on the gauge. It will also have a text block, which used to display the current musical note. According to these, over time the performer will learn to put their hands in the correct place for each note.