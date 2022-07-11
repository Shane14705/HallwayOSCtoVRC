#pragma once
#include <boost\asio.hpp>;
#include <boost\array.hpp>;
class OSCServer
{
public:
	OSCServer(boost::asio::io_context& io_context);
	

	~OSCServer();

private:
	boost::asio::ip::udp::socket socket_;
	boost::array<int, 8> recv_buff;
	void start_listening();
};

