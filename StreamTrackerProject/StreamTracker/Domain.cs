namespace StreamTracker;

public class StreamingService {
    public string service_name { get;}
    public string current_subscription {get;}

    public StreamingService(string service, string subscription) {
        this.service_name = service;
        this.current_subscription = subscription;
    }

    public override string ToString() {
        return this.service_name;
    }
}

public class Programs {
    public string program_name { get;}
    public string show_movie {get;}
    public string streaming_service {get;}
    public bool completed {get;}

    public Programs(string program, string show, string service, bool complete) {
        this.program_name = program;
        this.show_movie = show;
        this.streaming_service = service;
        this.completed = complete;
    }

    public override string ToString() {
        return this.program_name;
    }
}

public class LastEpisodeWatched {
    public string program { get;}
    public int season_number {get;}
    public int episode_number {get;}

    public LastEpisodeWatched(string program_name, int season, int episode) {
        this.program = program_name;
        this.season_number = season;
        this.episode_number = episode;
    }

    public override string ToString() {
        return this.program;
    }

}

public class Ranking {
    public string first_up { get;}
    public string second_up {get;}
    public string third_up {get;}

    public Ranking(string first, string second, string third) {
        this.first_up = first;
        this.second_up = second;
        this.third_up = third;
    }

}