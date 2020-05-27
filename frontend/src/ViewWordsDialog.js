import React, { Component } from 'react';
import { Button } from '@material-ui/core';
import Dialog from '@material-ui/core/Dialog';
import DialogTitle from '@material-ui/core/DialogTitle';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

export default class ViewWordsDialog extends Component {
    constructor(props) {
        super(props);
        this.state = {
            open: false,
            wordsList: ["espouse"]
        };
    }

    handleOpen = () => {
        console.log("OPENED");
        fetch('http://localhost:5000/api/words')
            .then(response => response.json())
            .then(data => this.setState({  open: true, wordsList: data }));
    }

    handleClose = () => {
        this.setState({
            open: false
        })
    }

    displayWords = () => {
        return (<div> <List>
            {this.state.wordsList.map(word => 
                <ListItem> <ListItemText> {word} </ListItemText> </ListItem>)}
        </List> </div>);
    }

    render() {
        
        console.log("STATE IS " + this.state.open)
        console.log("DATA " + this.state.wordsList )
        return <div>
            <Button variant="outlined" color="primary" onClick={this.handleOpen}> View Words </Button>
            <Dialog onClose={this.handleClose} open={this.state.open}>
                <DialogTitle id="simple-dialog-title">Words</DialogTitle>
                {this.displayWords()}
            </Dialog>
        </div>
    }
}

