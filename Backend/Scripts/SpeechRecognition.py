import speech_recognition as sr
import os
import sys
import base64
from pydub import AudioSegment


if __name__ == "__main__":
    # get encoded string
    encodedString = sys.argv[1]

    # get the location of where the files are
    __location__ = os.path.realpath(os.path.join(os.getcwd(), os.path.dirname(__file__)))
    mp3_file_location = os.path.join(__location__, 'speech.mp3')
    wav_file_location = os.path.join(__location__, 'speech.wav')

    # convert the encoded audio into mp3 file
    mp3_file = open(mp3_file_location, "wb")
    decodedString = base64.b64decode(encodedString)
    mp3_file.write(decodedString)
    mp3_file.close()

    # convert mp3 file to wav file
    mp3_segment = AudioSegment.from_mp3(mp3_file_location)
    mp3_segment.export(wav_file_location, format="wav")

    # get the audio from source
    r = sr.Recognizer()
    with sr.WavFile(wav_file_location) as source: 
        audio = r.record(source)

    # convert the audio
    try:
        print("Transcription: " + r.recognize_google(audio))
    except sr.UnknownValueError: 
        print("Cannot understand audio") 