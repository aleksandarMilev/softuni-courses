function printMovieInfo(commands) {
    const addMovieCommand = 'addMovie';
    const directedByCommand = 'directedBy';
    const dateCommand = 'onDate';
    const movies = [];

    for(const command of commands) {
        if(command.includes(addMovieCommand)) {
            const movie = {
                name: command.substring(addMovieCommand.length + 1)
            };

            movies.push(movie);

        } else if(command.includes(directedByCommand)) {
            const[movieName, directorName] = command.split(` ${directedByCommand} `);
            const movie = movies.find(movie => movie.name === movieName);

            if(movie) {
                movie.director = directorName;
            }
            
        } else if(command.includes(dateCommand)){
            const[movieName, date] = command.split(` ${dateCommand} `);
            const movie = movies.find(movie => movie.name === movieName);
            
            if(movie) {
                movie.date = date;
            }
        }
    }

    const validMovies = movies.filter(movie => movie.director && movie.date);

    for(const movie of validMovies) {
        console.log(JSON.stringify(movie));
    }
}