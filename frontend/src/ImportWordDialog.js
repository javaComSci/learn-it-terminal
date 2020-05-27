import React from 'react';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';

export default function ImportWordDialog() {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
        setOpen(true);
  };

  const handleClose = () => {
        setOpen(false);
  };

  const handleImportClose = () => {
        setOpen(false);
  }

  return (
    <div>
      <Button variant="outlined" color="primary" onClick={handleClickOpen}>
        Add words
      </Button>
      <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
        <DialogTitle id="form-dialog-title">Import words</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter name of file to import words from
          </DialogContentText>
          <TextField
            autoFocus
            margin="dense"
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Cancel
          </Button>
          <Button onClick={handleImportClose} color="primary">
            Import
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
}