function filterSongs(songsInput) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;        
            this.name = name;        
            this.time = time;        
        }
    }

    const songsCount = songsInput.shift();
    const filterType = songsInput.pop();

    for(const song of songsInput) {
        const[typeList, name, time] = song.split('_');
        const currentSong = new Song(typeList, name, time);

        if(currentSong.typeList === filterType || filterType === 'all') {
            console.log(currentSong.name);
        }
    }
}