import speech_recognition as sr
from pydub import AudioSegment


sound = AudioSegment.from_mp3("/path/to/file.mp3")
sound.export("/output/path/file.wav", format="wav")

r = sr.Recognizer()
with sr.WavFile("speech.wav") as source: 
    audio = r.record(source)

try:
    print("Transcription: " + r.recognize_google(audio))
except sr.UnknownValueError: 
    print("Cannot understand audio") 