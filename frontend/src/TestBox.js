import React, { Component } from 'react';
import { Button } from '@material-ui/core';
import CardActions from '@material-ui/core/CardActions';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';
import { ReactMic } from 'react-mic';

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
        this.setState({
            record: true
        });
    }


    stopRecord = () => {
        this.setState({
            record: false
        });
    }


    onData = (recordedBlob) => {
        console.log("RECORDING IS: " + recordedBlob);
    }
     

    onStop = (recordedBlob) => {
        console.log("RECORDED IS: " + recordedBlob);
        this.setState({
            recording: recordedBlob
        })
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
                    <Card style={{ display: "inline-block", width: "41%", boxShadow: '0 3px 2px 2px rgba(0, 0, 135, .3)', borderRadius: 3}}>
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
                            <div style={{width: "50%", textAlign: "center"}}>
                                <ReactMic
                                    style={{display: "inline-block", width: 20}}
                                    record={this.state.record}
                                    className="sound-wave"
                                    mimeType="audio/wav"
                                    onStop={this.onStop}
                                    onData={this.onData}
                                    strokeColor="#000000"
                                    backgroundColor="#c5cae9" />
                            </div>
                        </CardContent>
                    </Card>
                  
                </div>
            )
        }
    }
}
