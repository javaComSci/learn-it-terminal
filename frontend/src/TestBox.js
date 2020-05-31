import React, { Component } from 'react';
import { Button } from '@material-ui/core';
import CardActions from '@material-ui/core/CardActions';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { ReactMic } from 'react-mic';
var btoa = require('btoa');
const MicRecorder = require('mic-recorder-to-mp3');

const Mp3Recorder = new MicRecorder({ bitRate: 128 });

export default class TestBox extends Component {
    constructor(props) {
        super(props);
        this.state = {
            testing: false,
            record: false,
            wordsList: [],
            currentIndex: 0,
            recordedBlob: null
        };
    }

    startTest = () => {
        fetch('http://localhost:5000/api/words')
            .then(response => response.json())
            .then(data => this.setState({  testing: true, wordsList: data, currentIndex: 0 }));
    }

    startRecord = () => {
        Mp3Recorder.start().then(() => this.setState({record: true})).catch((e) => console.log(e));
    }


    stopRecord = () => {
       Mp3Recorder.stop().getMp3()
       .then(([buffer, blob]) => {
        const file = new File(buffer, 'tempaudio.mp3', {
            type: blob.type
          });
         
          var reader = new FileReader();
          reader.readAsDataURL(file); 
          reader.onloadend = function() {
              var base64data = reader.result;    
              console.log(base64data);
              fetch("http://localhost:5000/api/definition", {
                  method: "PUT",
                  headers: {
                  "Accept": "application/json",
                  "Content-Type": "application/json",
                  },
                  body: JSON.stringify({
                      definitionaudio: base64data
                  })
              })
          }
      }).then(() => this.setState({record: false})).catch((e) => console.log(e));
    }

    render() {
        let testButton = (<div>
            <Button variant="outlined" color="primary" onClick={this.startTest}>
                Test Words
            </Button>
        </div>);
        if(this.state.testing == false) {
            return (
                <div style={{padding: 20}}>
                    {testButton}
                </div>
            )
        } else {
            return (
                <div style={{textAlign: "center", padding: 20}}>
                    <Card style={{ textAlign: "center", display: "inline-block", width: "41%", boxShadow: '0 3px 2px 2px rgba(0, 0, 135, .3)', borderRadius: 3}}>
                        <CardContent>
                            <Typography style={{fontSize: 14}} color="textSecondary">
                                Definition of:
                            </Typography>
                            <Typography variant="h5" component="h2">
                                {this.state.wordsList[this.state.currentIndex]}
                            </Typography>
                            <CardActions style={{display: "inline-block", textAlign: "center", alignItems: "center"}}>
                                <Button size="small" onClick={this.startRecord}>Start Recording</Button>
                                <Button size="small" onClick={this.stopRecord}>Stop Recording</Button>
                            </CardActions>
                            <div style={{width: "50%", textAlign: "center", paddingLeft: "25%"}}>
                                {this.state.record ? "Recording" : "Not recording"}
                            </div>
                        </CardContent>
                    </Card>
                  
                </div>
            )
        }
    }
}
