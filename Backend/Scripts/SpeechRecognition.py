import speech_recognition as sr

r = sr.Recognizer()
with sr.WavFile("speech.wav") as source: 
    audio = r.record(source)

try:
    print("Transcription: " + r.recognize_google(audio))
except sr.UnknownValueError: 
    print("Cannot understand audio") 