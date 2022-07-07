#pragma once
#include <boost\asio.hpp>;
class OSCServer
{
public:
	OSCServer(boost::asio::io_context& io_context);
	

	~OSCServer();

private:
	boost::asio::ip::udp::socket socket_;

	void start_listening();
};

