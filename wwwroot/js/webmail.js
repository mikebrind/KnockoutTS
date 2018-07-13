define(["require", "exports", "../lib/knockout/dist/knockout"], function (require, exports, ko) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    class WebMailViewModel {
        constructor() {
            // Data
            this.folders = ["Inbox", "Archive", "Sent", "Spam"];
            this.chosenFolderId = new ko.observable();
            this.chosenFolderData = new ko.observable();
            this.chosenMailData = new ko.observable();
            // Behaviours
            // Load mail for folder
            this.goToFolder = (folder) => {
                this.chosenFolderId(folder);
                this.chosenMailData(null); // Stop showing a single mail
                fetch(`/api/mail/getfolder?folder=${folder}`)
                    .then(function (response) {
                    return response.json();
                }).then(this.chosenFolderData);
            };
            // Load individual mail 
            this.goToMail = (mail) => {
                this.chosenFolderId(mail.folder);
                this.chosenFolderData(null); // Stop showing a folder
                fetch(`/api/mail/getmail?mailId=${mail.id}`)
                    .then(function (response) {
                    return response.json();
                }).then(this.chosenMailData);
            };
            // Show inbox by default
            this.goToFolder("Inbox");
        }
    }
    class Mail {
    }
    class Folder {
    }
    ko.applyBindings(new WebMailViewModel());
});
//# sourceMappingURL=webmail.js.map