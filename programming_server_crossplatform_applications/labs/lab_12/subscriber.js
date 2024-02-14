import redis from 'redis';

(async () => {

    const subscriber = redis.createClient();
    await subscriber.connect();

    await subscriber.subscribe('myChanel', (message) => {
        console.log(message);
    });

})();